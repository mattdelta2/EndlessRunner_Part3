using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int coin = 0;

    public TextMeshProUGUI coinText;
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coin")
        {
            coin++;
            coinText.text = "Coin: " + coin.ToString();
            Debug.Log(coin);
            Destroy(other.gameObject);
        }
    }
}
