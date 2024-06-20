using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    public GameObject enemy1;
    public Vector3[] spawnPosition;

   

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
      
    }

    void SpawnEnemy()
    {
        int randomPosition = Random.Range(0, spawnPosition.Length);

         Instantiate(enemy1, spawnPosition[randomPosition], enemy1.transform.rotation);

    }
}
