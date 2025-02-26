using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Police : MonoBehaviour
{
    [SerializeField] private bool canMove = false;
    [SerializeField] private Transform aDestination;
    [SerializeField] private Transform bDestination;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator;
    private Transform targetPoint;
    
    [SerializeField] private bool canBeTriggeredByDoor = false;

    void OnEnable()
    {
        Messenger.AddListener(EventKey.CABINET_DOOR_OPEN, OnCabinetDoorOpen);
    }

    void OnDisable()
    {
        Messenger.RemoveListener(EventKey.CABINET_DOOR_OPEN, OnCabinetDoorOpen);
    }
    void Start()
    {
        if(aDestination != null) targetPoint = aDestination;
        // canMove = true;
        if (canMove == true) animator.SetBool("canMove", true);

        Debug.Log("canMove: " + canMove);
    }

    void Update()
    {
        if (!canMove) return;

        // Xoay nhân vật theo hướng di chuyển
        Vector3 direction = (targetPoint.position - transform.position).normalized;
        direction.y = 0; // Đảm bảo không bị thay đổi chiều cao khi xoay

        if (direction.magnitude > 0.1f) // Tránh xoay liên tục khi không di chuyển
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }

    void FixedUpdate()
    {
        if (!canMove) return;

        // Tính toán hướng di chuyển
        Vector3 direction = (targetPoint.position - rb.position).normalized;
        direction.y = 0; // Giữ nguyên chiều cao Y

        // Cập nhật vận tốc
        rb.velocity = direction * moveSpeed;

        // Kiểm tra khoảng cách để đổi hướng
        if (Vector3.Distance(rb.position, targetPoint.position) < 0.5f)
        {
            Debug.Log("Change direction");
            targetPoint = (targetPoint == aDestination) ? bDestination : aDestination;
        }
    }


    void OnCabinetDoorOpen() {
        if (canBeTriggeredByDoor) {
            canMove = true;
            animator.SetBool("canMove", true);
        }
    }
}
