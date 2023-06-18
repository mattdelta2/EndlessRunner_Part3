using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{

    public static CoinManager inst;
    int coins;

    public TextMeshProUGUI Coins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        inst = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        coins++;
        Coins.text = "Coins: " + coins.ToString();
        if(coins == 5)
        {
            SceneManager.LoadScene("ShootingBossScene");
        }

    }
}
