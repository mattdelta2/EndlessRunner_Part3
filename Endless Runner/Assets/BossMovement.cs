using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Animator bossAnimation;
    public Transform boss;
    public float currentDistance;
    public float bossSpeed = 20;
    public Vector3 posistion;
    // Start is called before the first frame update
    void Start()
    {
        Follow(posistion, bossSpeed);
           
    }

    
    public void Follow(Vector3 pos, float speed)
    {
        posistion = pos - Vector3.forward * currentDistance;
        boss.position = Vector3.Lerp(boss.position, posistion, Time.deltaTime * speed / currentDistance);
    }
}
