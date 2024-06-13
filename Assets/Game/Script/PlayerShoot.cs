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
}
