using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController playerController;
    private Vector3 moveVector;
    public float horizontalSpeed = 10.0f;
    public float verticalSpeed = 0.0f;
    private float gravity = 5.0f;
    public float boostSpeed;
    public float speedCooldown; 
    private float normalSpeed;
    private bool isDead = false;
    private float speed = 6f; //character movement speed; 5f
    bool isJump = false;
    public bool comingDown = false;
    public GameObject playerObject;

    
    public DeathMenu deathMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        if (isDead)
        {
            return;
        }
        ;
        moveVector = Vector3.zero; //sets movement

        if (playerController.isGrounded)
        {
            verticalSpeed = 0.5f;
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;

        }
        moveVector.x = Input.GetAxis("Horizontal") * speed;
        moveVector.y = verticalSpeed;
        moveVector.z = speed;

         //playerController.Move((Vector3.forward * speed) * Time.deltaTime, Space.World);
       
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundry.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundry.rightSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
            }
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            if(isJump == false)
            {
                isJump = true;
                playerObject.GetComponent<Animator>().Play("Jump");
                StartCoroutine(JumpSeq());
            }
        }
        if(isJump == true)
        {
            if(comingDown == false)
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

    private void OnTriggerEnter(Collider other) //when player goes through speed boost pick up, their speed increases 
    {
        if (other.CompareTag("SpeedBoost"))
        {
            speed = boostSpeed;
            StartCoroutine("SpeedDuration");
        }
        if(other.CompareTag("Obsticle"))
        {
            Death();
        }
    }
    IEnumerator SpeedDuration() //sets speed back to normal
    {
        yield return new WaitForSeconds(speedCooldown);
        speed = normalSpeed;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit) //called everytime objects hits obstales
    {
        if(hit.point.z > transform.position.z + playerController.radius)
        {
            Death();
        }
        
    }

    
    private void Death()
    {
        isDead = true;
        
        Debug.Log("You have DIED");
        SceneManager.LoadScene("DeathMenu");
        
       
        
       
        
    }
}
