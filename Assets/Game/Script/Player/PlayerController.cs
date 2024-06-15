using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public Camera mainCamera;
    public LayerMask groundLayer;

    //private bool isMoving = false;
    void Update()
    {
        MovePlayer();
        Aim();


    }
    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundLayer))
            return (success: true, position: hitInfo.point);
        else
            return (success: false, position: Vector3.zero);
    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();

        if (success)
        {
            var direction = position - transform.position;

            direction.y = 0f;

            transform.forward = direction;
        }
    }
}
