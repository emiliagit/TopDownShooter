using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float currentHealth;


    public GameObject deathEffect;
    public Transform deathEffectPoint;


    private void Start()
    {
        currentHealth = 5;
    }


    private void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void TakeDamage(float damage)
    {

        currentHealth -= damage;

    }


    protected void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, deathEffectPoint.position, deathEffectPoint.rotation);
            Debug.Log("animacion muerte instanciada");
        }

        Destroy(gameObject);
    }

}
