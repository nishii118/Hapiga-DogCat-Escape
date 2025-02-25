using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : Singleton<JoystickMove>
{
    [SerializeField] private Joystick movementJoystick;
    public float playerSpeed;
    [SerializeField] private Rigidbody rb;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    public void SetRigidbody(Rigidbody rigidbody)
    {
        rb = rigidbody;
    }

    void PlayerMovement()
    {
        Vector3 moveDirection = new Vector3(movementJoystick.Direction.x, 0, movementJoystick.Direction.y);

        if (moveDirection.magnitude > 0.1f) // Kiểm tra nếu có đầu vào từ joystick
        {
            // Cập nhật vận tốc
            rb.velocity = moveDirection * playerSpeed;

            // Xác định góc quay mong muốn
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            // Xoay từ từ để hướng về mục tiêu một cách mượt mà
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * 10f);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
