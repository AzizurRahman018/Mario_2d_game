using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float moveSpeed = 1f;
    private Rigidbody2D myBody;
    private Animator anim;
    private bool moveLeft;
    public Transform down_Collision;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        moveLeft = true ;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }
        else
        {
            myBody.velocity = new Vector2 (moveSpeed, myBody.velocity.y);
            
        }

        CheckCollision();    

    }

    void CheckCollision()
    {

        if (!Physics2D.Raycast(down_Collision.position, Vector2.down, 0.1f))
        {
           ChangeDiraction();

        }
        
    }

    void ChangeDiraction()
    {
        moveLeft = !moveLeft;
        Vector3 tempScale = transform.localScale;
        if (moveLeft)
        {
            tempScale.x = Math.Abs(tempScale.x);
            //positive valu x like 2
            
        }
        else
        {
            tempScale.x = -Math.Abs(tempScale.x);
            //negative valu x like -2 
        }

        transform.localScale = tempScale;
    }
        
    
}
























