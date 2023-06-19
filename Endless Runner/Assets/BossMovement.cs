using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Animator bossAnimation;
    public Transform boss;
    public float currentDistance;
    public float bossSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    public void Follow(Vector3 pos, float speed)
    {
        Vector3 position = pos - Vector3.forward * currentDistance;
        boss.position = Vector3.Lerp(boss.position, position, Time.deltaTime * speed / currentDistance);
    }
}
