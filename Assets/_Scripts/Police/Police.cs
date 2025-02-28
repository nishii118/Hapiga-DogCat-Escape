using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Police : MonoBehaviour
{
    [SerializeField] private bool canMove = false;
    // [SerializeField] private Transform aDestination;
    // [SerializeField] private Transform bDestination;
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator;
    private Transform targetPoint;
    
    [SerializeField] private bool canBeTriggeredByDoor = false;

    private int currentWayPointIndex;

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
    


        //init
        currentWayPointIndex = 0;
        if (waypoints.Count > 0) targetPoint = waypoints[currentWayPointIndex];
        if (canMove == true) animator.SetBool("canMove", true);

        Debug.Log("canMove: " + canMove);
    }

    void Update()
    {
        if (!canMove || waypoints.Count == 0) return;

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
        if (!canMove || waypoints.Count == 0) return;

        // Tính toán hướng di chuyển
        Vector3 direction = (targetPoint.position - rb.position).normalized;
        direction.y = 0; // Giữ nguyên chiều cao Y

        // Cập nhật vận tốc
        rb.velocity = direction * moveSpeed;

        // Kiểm tra khoảng cách để đổi hướng
        if (Vector3.Distance(rb.position, targetPoint.position) < 0.5f)
        {
            Debug.Log("Change direction");
            // targetPoint = (targetPoint == aDestination) ? bDestination : aDestination;
            currentWayPointIndex = (currentWayPointIndex + 1) % waypoints.Count;
            targetPoint = waypoints[currentWayPointIndex];
            Debug.Log(currentWayPointIndex);
        }
    }


    void OnCabinetDoorOpen() {
        if (canBeTriggeredByDoor) {
            canMove = true;
            animator.SetBool("canMove", true);
        }
    }

    public void PlayElectrizedAnimation() {
        StartCoroutine(PlayElectrizedAnimationCoroutine());
    }

    IEnumerator PlayElectrizedAnimationCoroutine() {
        animator.CrossFade("Electrized", 0.1f);
        yield return null;
        // yield return new WaitForSeconds(1f);
        // animator.CrossFade("Idle", 0.1f);
    }

    public void StopPoliceMovement() {
        canMove = false;
        animator.SetBool("canMove", false);
        rb.velocity = Vector3.zero;
    }
}
