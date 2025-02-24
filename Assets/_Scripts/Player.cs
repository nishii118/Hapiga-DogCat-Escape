using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private bool isDragging = false;
    [SerializeField] private float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
    }

    void InputPlayer()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            startPos = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButton(0) && isDragging) 
        {
            endPos = Input.mousePosition;
            Vector2 moveDirection = (endPos - startPos).normalized;

            Vector3 moveXZ = new Vector3(moveDirection.x, 0, moveDirection.y); 
            transform.position += moveXZ * moveSpeed * Time.deltaTime;
            // startPos = endPos; 
        }
        else if (Input.GetMouseButtonUp(0)) 
        {
            
            isDragging = false;
        }
    }
}
