using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public  int coin = 0;
    public AudioClip audioSource;

    public TextMeshProUGUI coinText;
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coin")
        {
            
            coin++;
            AudioSource.PlayClipAtPoint(audioSource, transform.position);
            coinText.text = "Coin: " + coin.ToString();
            Debug.Log(coin);
            Destroy(other.gameObject);

        }
    }
}
