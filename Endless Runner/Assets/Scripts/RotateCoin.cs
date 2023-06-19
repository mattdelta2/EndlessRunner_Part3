using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{

    public float rotateSpeed = 90f;
    public AudioClip coin;


     void Update()
    {
        transform.Rotate(0,0,rotateSpeed*Time.deltaTime);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        CoinManager.inst.IncreaseScore();
        AudioSource.PlayClipAtPoint(coin, transform.position);

        Destroy(gameObject);
    }

}
