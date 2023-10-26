using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class SpawnManager : MonoBehaviour

{

    public GameObject[] enemyPrefab;

    private int enemyIndex;

    private float enemyRange = 10f;

    private PlayerMovement playerControllerScript;


    // Start is called before the first frame update

    void Start()

    {

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();

        InvokeRepeating("SpawnEnemy", 2, 2);

    }



    void SpawnEnemy()

    {

        if (playerControllerScript.isGameOver == false)
        {
            Vector3 spawnPos = new Vector3(0, 10, Random.Range(-enemyRange, enemyRange));
            enemyIndex = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[enemyIndex], spawnPos, enemyPrefab[enemyIndex].transform.rotation);
        }

    }

}