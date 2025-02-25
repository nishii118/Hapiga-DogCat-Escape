
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    [SerializeField] private InputActionReference moveAction;
    // public Joystick joy; // Tham chiếu đến UI Joystick
    Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        moveDirection = new Vector3(input.x, 0, input.y).normalized;
    }

    void FixedUpdate()
    {
        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 0.1f); // Làm mượt xoay
        }

        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SuccessSpot"))
        {
            GameManager.Instance.LoadNextScene();
        }
    }








}
