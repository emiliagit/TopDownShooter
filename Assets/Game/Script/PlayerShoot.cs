using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Transform firePoint;

    public float bulletForce = 7f;

    private float tiempoUltimoDisparo;

    [SerializeField] private float cadenciaDisparo = 0.3F;


    private void Update()
    {
        MousePosition();

        if (Input.GetMouseButtonDown(0) && Time.time - tiempoUltimoDisparo > cadenciaDisparo)
        {
            ShootProjectile();
        }
    }
    protected virtual void ShootProjectile()
    {
        tiempoUltimoDisparo = Time.time;
        GameObject nuevaBala = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = nuevaBala.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.forward * -bulletForce, ForceMode2D.Impulse);
        Destroy(nuevaBala, 3f);
    }

    void MousePosition()
    {
        // Calcula la posici�n del mouse en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Aseg�rate de que la posici�n Z sea 0

        // Calcula la direcci�n desde el firePoint hacia la posici�n del mouse
        Vector3 direction = mousePosition - firePoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apunta el firePoint hacia la direcci�n del mouse
        firePoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
