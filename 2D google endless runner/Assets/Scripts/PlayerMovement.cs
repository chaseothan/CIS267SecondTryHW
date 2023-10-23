using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    private float inputHorizontal;
    public float jumpForce;
    private int numJumps;
    private int maxNumJumps;


    // Start is called before the first frame update
    void Start()
    {
      
        playerRigidBody = GetComponent<Rigidbody2D>();

        numJumps = 1;
        maxNumJumps = 1;

        
    }

    // Update is called once per frame
    void Update()
    {
   
        jump();
    }

    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && numJumps <= maxNumJumps)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);

            numJumps++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject);

        if(collision.gameObject.CompareTag("OB"))
        {
            //end game 
        }
        else if(collision.gameObject.CompareTag("Grounded"))
        {
            numJumps = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("DoubleJump"))
        {
            //give player double jump
            maxNumJumps = 2;
            //delete object from screen
            Destroy(collision.gameObject);

            //make this do something else later


        }
        else if(collision.gameObject.CompareTag("CoinCollectable"))
        {
            
        }
    }
    
}
