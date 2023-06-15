using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetAttraction : MonoBehaviour
{
    public float attractStrength = 5f;
    public float attractRange = 5f;

    private void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attractRange);
        foreach(Collider hitcollider in hitColliders)
        {
            if (hitcollider.CompareTag("Coin"))
            {
                Vector3 forceDistance = transform.position - hitcollider.transform.position;
                hitcollider.GetComponent<Rigidbody>().AddForce(forceDistance.normalized * attractStrength);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attractRange);
        Gizmos.color = Color.black;
    }

}
