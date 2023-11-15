using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float rate;
    public GameObject[] enemies;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
    }

    void SpawnEnemy()
    {
        Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-9.3f, 9.3f), 6, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
