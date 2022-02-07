using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour

{
    float timer = 0.0f;
    float seconds;
    [SerializeField] Vector3 spawnPlace;
    public bool onIsland = false;



    public GameObject enemyPrefab;






    void Update()
    {
       // print(seconds);
        timer += Time.deltaTime;
        seconds = timer % 60;
        if (seconds >= 10)
        {

            if (onIsland == false)
            {

                Instantiate(enemyPrefab, spawnPlace, Quaternion.identity);
                timer = 0;

            }
            else
            {
                timer = 0;
            }
        }

    }
}