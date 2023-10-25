using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightScript : MonoBehaviour
{
    public float movementSpeed;
    public float offset;
    private bool moveLeft;
    private float startPosx;
    // Start is called before the first frame update
    void Start()
    {
        startPosx = transform.position.x;
        moveLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveLilguy();
    }

    public void moveLilguy()
    {

        if (moveLeft)
        {

            //move left
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }
        else
        {
            //move the lil guy side to side
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }


        if (transform.position.x >= startPosx)
        {
            moveLeft = false;
        }

        if (transform.position.x <= startPosx - offset)
        {
            moveLeft = true;
        }
        //move side to side like we did with the saw 

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Dead");
        }
    }
}

