using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
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
        if (movementJoystick.Direction.y != 0 || movementJoystick.Direction.x != 0)
        {
            rb.velocity = new Vector3(movementJoystick.Direction.x * playerSpeed, 0, movementJoystick.Direction.y * playerSpeed);
            
        } else {
            rb.velocity = Vector3.zero;
        }
    }
}
