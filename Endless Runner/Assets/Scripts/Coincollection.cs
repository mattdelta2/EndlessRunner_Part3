using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coincollection : MonoBehaviour
{

    private int coin = 0;

    public TextMeshProUGUI coinText;
    void OnTriggerEnter(Collider other)
    {
       if(other.transform.tag == "Coin")
        {
            coin++;
            coinText.text = "Coin: " + coin.ToString();
            Debug.Log(coin);
            Destroy(other.gameObject);
        }
    }

}
