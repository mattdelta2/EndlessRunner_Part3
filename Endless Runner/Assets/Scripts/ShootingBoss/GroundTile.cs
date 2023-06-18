using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{

    GroundSpawner groundSpawner;

 
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        spawnObsticle();
        spawnBossCoins();


    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.spawnTile();
        Destroy(gameObject, 2);
        
    }


    void Update()
    {
        
    }

    public GameObject obsticlePrefab;

    void spawnObsticle()
    {
        int obsticlespawnIndex = Random.Range(2, 4);
        Transform spawnPoint = transform.GetChild(obsticlespawnIndex).transform;

        Instantiate(obsticlePrefab, spawnPoint.position,Quaternion.identity, transform);

    }


    public GameObject CoinPrefab;

    void spawnBossCoins()
    {
        int coinsToSpawn = 1;

        for(int i = 0; i < coinsToSpawn; i++)
        {
           GameObject temp =  Instantiate(CoinPrefab);
            temp.transform.position = getRandomPoint(GetComponent<Collider>());
        }
    }


    Vector3 getRandomPoint(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        if(point != collider.ClosestPoint(point))
        {
            point = getRandomPoint(collider);
        }

        point.y = 1;

        return point;


    }
}
