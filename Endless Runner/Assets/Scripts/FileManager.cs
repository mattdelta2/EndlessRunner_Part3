using System.Collections.Generic;
using UnityEngine;


public class FileManager : MonoBehaviour
{

    public GameObject[] tilePrefabDungeon;
    private List<GameObject> usedTiles;
    public GameObject[] tilePrefabCity;

    private Transform characterTransform;
    private float Zspawner = 0.0f;
    private float tileLength = 20f; // length of tiles
    private int tileAmount = 11; //the amount of tiles that spawn as soon as the player moves past a sectiom
    private float safe = 15.0f;
    private int finalPrefabIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        usedTiles = new List<GameObject>();
        characterTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i <tileAmount; i++)
        {
            TileSpawn(); //one you cross a certain point it creates a new tile
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(characterTransform.position.z - safe > (Zspawner - tileAmount * tileLength))
        {
            TileSpawn();
            DeleteTile();
        }
    }
    private void TileSpawn(int prefabsList = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabDungeon[PrefabRandomIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * Zspawner;
        Zspawner += tileLength;
        usedTiles.Add(go);
    }
    private void DeleteTile()
    {
        Destroy(usedTiles[0]);
        usedTiles.RemoveAt(0);
    }

    private int PrefabRandomIndex()
    {
        if(tilePrefabDungeon.Length <= 1)
        {
            return 0;


        }
        int randomIndex = finalPrefabIndex;
        while(randomIndex == finalPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabDungeon.Length);
        }
        finalPrefabIndex = randomIndex;
        return randomIndex;
    }
}
