using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTile : MonoBehaviour
{
    
    SpawnTiles spawnTiles;
    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        
        spawnTiles = GameObject.FindObjectOfType<SpawnTiles>();
        SpawnCoins();
        SpawnObsticles();
        SpawnPowerUps();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnTiles.SpawnTile();
        Destroy(gameObject,2);
        
    }

    public GameObject[] Dungeonobsticles;
    public GameObject[] CityObsticles;

    void SpawnObsticles()
    {
        //choose random point
        int randomObsticleToSpawn = Random.Range(0, 3);
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        //spawn obsticle
        Instantiate(Dungeonobsticles[randomObsticleToSpawn], spawnPoint.position, Quaternion.identity, transform);

       /* if(score.coin ==5)
        {
            int CityrandomObsticleToSpawn = Random.Range(0, 3);
            int CityobstacleSpawnIndex = Random.Range(2, 5);
            Transform CityspawnPoint = transform.GetChild(CityobstacleSpawnIndex).transform;
            Instantiate(CityObsticles[CityrandomObsticleToSpawn], CityspawnPoint.position, Quaternion.identity, transform);

        }*/


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
        
    }
    public GameObject Powerups;

    void SpawnPowerUps()
    {
        float powerupsToSpawn = 1f;
        for(int i = 0;i < powerupsToSpawn;i++)
        {
            GameObject temp = Instantiate(Powerups);
            temp.transform.position = getRandomPoint(GetComponent<Collider>());


        }

    }
}
