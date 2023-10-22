using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private int enemyIndex;
    private float enemyRange = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(0, 10, Random.Range(-enemyRange, enemyRange));
        enemyIndex = Random.Range(0, enemyPrefab.Length);
        Instantiate(enemyPrefab[enemyIndex], spawnPos, enemyPrefab[enemyIndex].transform.rotation);
    }
}
