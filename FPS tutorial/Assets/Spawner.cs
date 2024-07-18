using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; 

    public float rateOfSpawn = 1000000000000000000f;
    private float timeToNextSpawn = 0f;

    // Update is called once per frame
    async void Update()
    {
        
        timeToNextSpawn = Time.time + 1f / rateOfSpawn;
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        await Task.Delay(TimeSpan.FromSeconds(100f));
           
    }
}
