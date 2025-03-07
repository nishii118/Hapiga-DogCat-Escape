using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : Singleton<JoystickMove>
{
    [SerializeField] private Joystick movementJoystick;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Animator playerAnim;

    private bool canMove = true;

    void OnEnable()
    {
        Electricity.OnPlayerBeElectrized += () => canMove = false;
        Level.OnLevelBeLoaded2 += () => canMove = true;
    }

    void OnDisable()
    {
        Electricity.OnPlayerBeElectrized -= () => canMove = false;
        Level.OnLevelBeLoaded2 -= () => canMove = true;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rb == null && playerAnim == null) return;
        if(canMove) PlayerMovement();
    }

    public void SetRigidbody(Rigidbody rigidbody)
    {
        rb = rigidbody;
    }

    public void SetPlayerAnim(Animator anim)
    {
        playerAnim = anim;
    }
    void PlayerMovement()
    {
        Vector3 moveDirection = new Vector3(movementJoystick.Direction.x, 0, movementJoystick.Direction.y).normalized;

        if (moveDirection.magnitude > 0.1f) // Kiểm tra nếu có đầu vào từ joystick
        {
            // Cập nhật vận tốc

            // Xác định góc quay mong muốn
            rb.velocity = moveDirection * playerSpeed;

            // Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            // rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.rotation = Quaternion.RotateTowards(rb.rotation,
                targetRotation, 1080 * Time.deltaTime);
            

            // update anim 
            playerAnim.SetFloat("MoveSpeed", rb.velocity.magnitude);

        }
        else
        {
            rb.velocity = Vector3.zero;
            playerAnim.SetFloat("MoveSpeed", 0);
        }
    }

    void StopPlayerMovement()
    {
        canMove = false;
        rb.velocity = Vector3.zero;
        playerAnim.SetFloat("MoveSpeed", 0);
    }

}
