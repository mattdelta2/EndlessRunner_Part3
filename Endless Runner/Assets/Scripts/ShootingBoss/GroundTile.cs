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
}
