using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    int BossHealth = 25;
    public static GameManager Inst;

    public TextMeshProUGUI bossHealth;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    private void Awake()
    {
        Inst = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHealth()
    {
        BossHealth--;
        bossHealth.text = "Boss Health = " + BossHealth;
        if (BossHealth == 0)
        {
            SceneManager.LoadScene("GameScene");
        }
    }



}
