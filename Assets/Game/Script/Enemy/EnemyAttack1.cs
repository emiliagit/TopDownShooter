using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack1 : MonoBehaviour
{
    public float detectionRadius = 6f; // Radio de detección
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform projectileSpawnPoint; // Punto de spawn del proyectil
    public float fireRate = 1f; // Tasa de disparo (proyectiles por segundo)

    private Transform player; // Referencia al jugador
    private float nextFireTime = 0f; // Tiempo para el próximo disparo

    public float bulletForce = 7f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encontrar al jugador por tag
    }

    void Update()
    {
        // Comprobar la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            // Si el jugador está dentro del radio de detección, disparar proyectiles
            if (Time.time >= nextFireTime)
            {
                FireProjectile();
                nextFireTime = Time.time + 1f / fireRate; // Actualizar el tiempo para el próximo disparo
            }
        }
    }

    void FireProjectile()
    {
        // Calcular la dirección hacia el jugador
        Vector3 directionToPlayer = (player.position - projectileSpawnPoint.position).normalized;

        // Instanciar el proyectil en el punto de spawn
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

        // Configurar la dirección y velocidad del proyectil
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = directionToPlayer * bulletForce;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar el radio de detección en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
