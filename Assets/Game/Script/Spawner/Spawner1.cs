using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    //spawn de enemigos en mapa
    //public GameObject enemyPrefab;
    //public float spawnInterval = 2f; 
    //private float timeSinceLastSpawn = 0.0f;

   
    public GameObject enemy1;
    public Vector3[] spawnPosition;

   
    public int maxEnemyCount = 8;
    public int currentEnemyCount = 0;
   

    bool spawnerActive = true;
    public float delay;

    private void Start()
    {
        //delay = 10f;
        spawnerActive = true;
        StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        while (spawnerActive)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(delay);
        }
    }

    private void Update()
    {
        if (currentEnemyCount >= maxEnemyCount)
        {
            spawnerActive = false;
            //Debug.Log("se desactivo spawner");
        }
        if (currentEnemyCount < maxEnemyCount)
        {
            spawnerActive = true;
            //Debug.Log("se activo spawner");
        }
    }

    void SpawnEnemy()
    {
        if (currentEnemyCount < maxEnemyCount)
        {
            currentEnemyCount++;//contador de enemigos

            //int randomIndex = Random.Range(0, enemy1.Length);
            int randomPosition = Random.Range(0, spawnPosition.Length);

            //GameObject randomEnemy = enemy1[randomIndex];

            Instantiate(enemy1, spawnPosition[randomPosition], enemy1.transform.rotation);

        }
    }
}
