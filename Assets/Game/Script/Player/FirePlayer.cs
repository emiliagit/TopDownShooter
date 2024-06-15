using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlayer : MonoBehaviour
{
    public GameObject firePrefab;

    private void Start()
    {

    }

    private void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            GameObject fire = Instantiate(firePrefab, transform.position, Quaternion.identity);
            Destroy(fire, 1f);
            Debug.Log("Colision");
            Destroy(gameObject);
        }

        if (collision.gameObject.TryGetComponent(out EnemyLife enemy))
        {
            enemy.TakeDamage(10);
            Debug.Log("da�o de 10 a enemigo");
        }
    }
}
