using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPickup : MonoBehaviour
{
    public KeyCode Intangable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _ = GetComponent<Rigidbody>().velocity - new Vector3(2, 1, 1);

        if (Input.GetKeyDown(Intangable))
        {
            GetComponent<Rigidbody>().isKinematic = true;

        }
    }
}
