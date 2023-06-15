using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DatabaseAcess : MonoBehaviour
{

    MongoClient client = new MongoClient("mongodb+srv://ADMIN:ADMIN@gade.rftkd8e.mongodb.net/?retryWrites=true&w=majority");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> collection;

    // Start is called before the first frame update
    void Start()
    {

        database = client.GetDatabase("Data");
        collection = database.GetCollection<BsonDocument>("HighScores");








    }

    public async void SaveScoreToDatabase(string UserName, int score)
    {
        var document = new BsonDocument { { UserName, score } };
        await collection.InsertOneAsync(document);
    }


    public async Task<List<Highscore>> getScoresFromDataBase()
    {

        var allScoresTask = collection.FindAsync(new BsonDocument());
        var scoresAwaited = await allScoresTask;

        List<Highscore> highscores = new List<Highscore>();
        foreach (var score in scoresAwaited.ToList())
        {
            highscores.Add(Deserialize(score.ToString()));
        }

        return highscores;


    }

    private Highscore Deserialize(string rawJson)
    {

        //raw JSON  "{ \"_id\" : ObjectId(\"648a0db16e53b1690ca513ec\"), \"UserName\" : 100 }"
        var highScore = new Highscore();
        // remove first part

        var stringWithoutID = rawJson.Substring(rawJson.IndexOf("),") + 4);
        var username = stringWithoutID.Substring(0, stringWithoutID.IndexOf(":") -2);

        var score = stringWithoutID.Substring(stringWithoutID.IndexOf(":") + 2, stringWithoutID.IndexOf("}")-stringWithoutID.IndexOf(":"));

        highScore.userName = username;
        highScore.Score = Convert.ToInt32(score);


        return highScore;
    }
}

//inline class

public class Highscore
{
    public string userName { get; set; }
    public int Score { get; set; }
}

