using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float gravityMultiplier = 2f;
    private bool isGrounded;
    private Rigidbody rb;

    public Camera mainCamera;
    public LayerMask groundLayer;

    //public CharacterController controller; 
    //public Transform cameraTransform;

    public float turnSmoothTime = 0.1f; 
    float turnSmoothVelocity;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        RotateTowardsMouse();


    }
   

    void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        transform.Translate(direction * speed * Time.deltaTime, Space.World);

       

    }

   

    void RotateTowardsMouse()
    {
        Vector3 mousePosition = Input.mousePosition;

        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            Vector3 targetPosition = hit.point;

            Vector3 direction = targetPosition - transform.position;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;
            }
        }
    }
}
