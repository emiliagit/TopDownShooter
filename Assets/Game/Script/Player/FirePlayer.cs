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


    

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            GameObject fire = Instantiate(firePrefab, transform.position, Quaternion.identity);
            Destroy(fire, 1f);
            Debug.Log("Colision");
            Destroy(gameObject);
        }

        if (other.gameObject.TryGetComponent(out EnemyLife enemy))
        {
            enemy.TakeDamage(1);
            Debug.Log("daño de 10 a enemigo");
        }
       
    }
}
