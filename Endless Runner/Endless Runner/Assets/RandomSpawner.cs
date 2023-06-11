using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] pickUps;

    // Update is called once per frame
    void Update()
    {
        int randomIndex = Random.Range(0, pickUps.Length);
        Vector3 randomSpawn = new Vector3(Random.Range(-5, 3), 5, Random.Range(-5, 3));
        Instantiate(pickUps[randomIndex], randomSpawn, Quaternion.identity);
    }
}
