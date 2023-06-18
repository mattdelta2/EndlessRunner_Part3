using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTile : MonoBehaviour
{
    /*FileManager fileManager;
    // Start is called before the first frame update
    void Start()
    {
        fileManager = GameObject.FindObjectOfType<FileManager>();
        SpawnObsticles();
        SpawnCoins();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        fileManager.SpawnTile();
        Destroy(gameObject,2);
        
    }

    public GameObject[] obsticles;

    void SpawnObsticles()
    {
        int obstacleType = Random.Range(1, 4);
        int obsticleSpawnIndex = Random.Range(1, 4);
        Transform spawnpoint = transform.GetChild(obsticleSpawnIndex).transform;

        Instantiate(obsticles[obstacleType],spawnpoint.position,Quaternion.identity,transform);
    }

    public GameObject Coins;

    void SpawnCoins()
    {
        int coinsToSpawn = 1;

        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(Coins);
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

        if (point != collider.ClosestPoint(point))
        {
            point = getRandomPoint(collider);
        }

        point.y = 1;

        return point;


    }
    // Update is called once per frame
    void Update()
    {
        
    }*/
}
