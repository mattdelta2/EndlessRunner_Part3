using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayHighScore : MonoBehaviour
{

    private DatabaseAcess databaseAcess;
    private TextMeshPro highScoreOutPut;
    // Start is called before the first frame update
    void Start()
    {
        databaseAcess = GameObject.FindGameObjectWithTag("DatabaseAccess").GetComponent<DatabaseAcess>();
        highScoreOutPut = GetComponentInChildren<TextMeshPro>();

        Invoke("DisplayHighScoreTMP", 2);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async void DisplayHighScoreTMP()
    {
        var task = databaseAcess.getScoresFromDataBase();

        var result = await task;
        var output = "";
        foreach(var score in result)
        {
            output += " Score: " + score.Score + " \n";
        }

        highScoreOutPut.text = output;

    }
}
