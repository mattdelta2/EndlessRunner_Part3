using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coincollection : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        CollectableDisplay.coinCount += 1;
        this.gameObject.SetActive(false);
    }

}
