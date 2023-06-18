using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController playerController;
    bool isJump = false;
    public bool comingDown = false;
    public GameObject playerObject;
    public float speed = 5f;
   // public Rigidbody rb;

     float horizontalInput;
    public float horizontalMulti = 2f;
    public float LeftRightSpeed = 4;
    private bool isDead = false;





    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }


    void Update()
    {
        if (isDead)
        {
            return;
        }
        transform.Translate(Vector3.forward*Time.deltaTime*speed, Space.World);



        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundry.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * LeftRightSpeed);
            }
        }
        if(Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundry.rightSide)
            {
                transform.Translate(Vector3.right * Time.deltaTime * LeftRightSpeed);
            }
        }
        

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            if (isJump == false)
            {
                isJump = true;
                playerObject.GetComponent<Animator>().Play("Jump");
                StartCoroutine(JumpSeq());
            }
        }
        if (isJump == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 10, Space.World);
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -10, Space.World);
            }
        }
        IEnumerator JumpSeq()
        {
            yield return new WaitForSeconds(0.4f);
            comingDown = true;
            yield return new WaitForSeconds(0.4F);
            isJump = false;
            comingDown = false;
            playerObject.GetComponent<Animator>().Play("Running");
        }

    }
    private void OnControllerColliderHit(ControllerColliderHit hit) //called everytime objects hits obstales
    {
        if (hit.point.z > transform.position.z + playerController.radius)
        {
            Death();
        }

    }
    private void Death()
    {
        isDead = true;
        Debug.Log("You have DIED");
        



    }
}
