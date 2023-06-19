using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnTiles : MonoBehaviour
{
    public GameObject DungeonGroundTile;
    public GameObject CityGroundTile;
    Vector3 NextSpawnPoint;

    public Score score; 
    public void SpawnTile()
    {
        GameObject temp = Instantiate(DungeonGroundTile, NextSpawnPoint, Quaternion.identity);
        NextSpawnPoint = temp.transform.GetChild(1).transform.position;

       /* if(score.coin ==5)
        {
            GameObject temps = Instantiate(CityGroundTile, NextSpawnPoint, Quaternion.identity);
            NextSpawnPoint = temps.transform.GetChild(1).transform.position;
               

        }*/
    }
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();

        }
    }




    public void BossScene()
    {
        if (score.coin == 50)
        {
            SceneManager.LoadScene("ShootingBossScene");
        }
    }
}
