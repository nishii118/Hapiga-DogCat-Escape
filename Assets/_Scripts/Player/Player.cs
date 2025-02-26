
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // public float moveSpeed = 5f;
    // private Rigidbody rb;
    // [SerializeField] private InputActionReference moveAction;
    // // public Joystick joy; // Tham chiếu đến UI Joystick
    // Vector3 moveDirection;

    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        if (JoystickMove.Instance != null)
        {
            JoystickMove.Instance.SetRigidbody(GetComponent<Rigidbody>());
        }
    }

    // void Update()
    // {
    //     Vector2 input = moveAction.action.ReadValue<Vector2>();
    //     moveDirection = new Vector3(input.x, 0, input.y).normalized;


    //     // if (moveDirection.magnitude > 0.1f)
    //     // {
    //     //     Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
    //     //     rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 0.1f); // Làm mượt xoay
    //     // }

    //     // rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    //     rb.velocity = new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.z * moveSpeed);
    //     Debug.Log(rb.velocity);
    // }

    // void FixedUpdate()
    // {
    //     // if (moveDirection.magnitude > 0.1f)
    //     // {
    //     //     Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
    //     //     rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 0.1f); // Làm mượt xoay
    //     // }

    //     // // rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    //     // rb.velocity = new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.z * moveSpeed);
    // }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SuccessSpot"))
        {
            GameManager.Instance.LoadNextScene();
        }
    }








}
