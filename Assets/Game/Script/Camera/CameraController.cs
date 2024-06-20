using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{// El transform del jugador al que la c�mara seguir�.
    public Transform player;

    // La distancia a la que la c�mara debe seguir al jugador.
    public Vector3 offset;

    // Velocidad de seguimiento de la c�mara.
    public float followSpeed = 5f;

    void Start()
    {
        // Si no se ha definido un offset, lo establecemos a la distancia actual entre la c�mara y el jugador.
        if (offset == Vector3.zero && player != null)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Calcula la posici�n objetivo de la c�mara.
            Vector3 targetPosition = player.position + offset;

            // Suaviza el movimiento de la c�mara.
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
