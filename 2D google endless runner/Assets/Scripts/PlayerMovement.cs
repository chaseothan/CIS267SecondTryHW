using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public GameObject gunProjectile;
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    private float inputHorizontal;
    public float jumpForce;
    private int numJumps;
    private int maxNumJumps;


    public void DestroyObjects(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        }
    }


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
        

        if(collision.gameObject.CompareTag("Clear"))
        {
    
        }
        else if(collision.gameObject.CompareTag("Grounded"))
        {
            numJumps = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.CompareTag(""))
        //{
          
        //    //delete object from screen
        //    Destroy(collision.gameObject);

        //    //make this do something else later


        //}
        if(collision.gameObject.CompareTag("enemy"))
        {
            GameManager.Instance.GameOver();
        }
        else if (collision.gameObject.CompareTag("Clear"))
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject target in gameObjects)
            {
                GameObject.Destroy(target);
            }
            GameObject[] gameeObjects = GameObject.FindGameObjectsWithTag("Clear");
            foreach (GameObject target in gameeObjects)
            {
                GameObject.Destroy(target);
            }
        }
        else if (collision.gameObject.CompareTag("ScoreMultiplier"))
        {
            GameManager.Instance.setScore(GameManager.Instance.getScore() * 2);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Gun"))
        {
            GameObject projectile = Instantiate(gunProjectile);

            projectile.transform.position = collision.gameObject.transform.position;

            Destroy(collision.gameObject);
        }
    }

   
}
