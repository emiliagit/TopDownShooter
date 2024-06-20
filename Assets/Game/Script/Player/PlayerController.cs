using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public Camera mainCamera;
    public LayerMask groundLayer;

    public CharacterController controller;  // El controlador de carácter del jugador
    public Transform cameraTransform;

    public float turnSmoothTime = 0.1f;     // Suavidad de rotación
    float turnSmoothVelocity;

    //private bool isMoving = false;
    void Update()
    {
        //MovePlayer();
        //RotateTowardsMouse();


    }
    private void FixedUpdate()
    {
        MovePlayer();
        RotateTowardsMouse();
    }
    void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Calcular el ángulo objetivo en base a la dirección de la cámara
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            // Rotar al jugador hacia la dirección objetivo
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Mover al jugador en la dirección de la cámara
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

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
