using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDestroyer : MonoBehaviour
{

    public float turnSpeed = 90f;
    public AudioClip boss;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,turnSpeed*Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {

        /*if(other.gameObject.GetComponent<GroundTile>()  != null)
        {
            Destroy(gameObject);
            return;
        }*/
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        GameManager.Inst.DecreaseHealth();
        AudioSource.PlayClipAtPoint(boss, transform.position);



        Destroy(gameObject);
        
    }
}
