using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDropSpawner : MonoBehaviour
{
    [SerializeField] GameObject airDropPrefabs;
    [SerializeField] Vector3 spawnArea;
    [SerializeField] float spawnTimer;
    private float timer;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SpawnAirDrop();
            timer = spawnTimer;
        }
    }
    void SpawnAirDrop()
    {
        Vector3 position = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), 0, Random.Range(-spawnArea.z, spawnArea.z));
        GameObject newAirDrop = Instantiate(airDropPrefabs);
        newAirDrop.transform.position = position;
    }
}
