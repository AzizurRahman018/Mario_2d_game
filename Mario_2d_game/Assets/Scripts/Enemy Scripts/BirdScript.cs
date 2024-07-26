using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D myBody;
    private Animator anim;
    private Vector3 moveDirection = Vector3.left;
    private Vector3 originPosition;
    private Vector3 movePosition;
    public GameObject birdEggg;
    public LayerMask playerLayer;
    private bool attacked;
    private bool canMove;
    private float speed = 2f;
 
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        originPosition = transform.position;
        originPosition.x += 6f;
        movePosition = transform.position;
        movePosition.x -= 6f;

        canMove = true;


    }

    // Update is called once per frame
    void Update()
    {
        MoveTheBird();
        DropTheEgg();
    }

    void MoveTheBird()
    {

        if (canMove)
        {
            transform.Translate(moveDirection * speed * Time.smoothDeltaTime);

            if (transform.position.x >= originPosition.x)
            {
                moveDirection = Vector3.left;
                 ChangeDirection(0.5f);
            }
            else if (transform.position.x <= movePosition.x)
            {
                moveDirection = Vector3.right;
                 ChangeDirection(-0.5f);
            }
            
        }
        
    }
    void ChangeDirection(float direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;



    }

    void DropTheEgg()
    {
        if (!attacked)
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity,playerLayer))
            {
                Instantiate(birdEggg,
                    new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z),
                    Quaternion.identity);

                attacked = true;
                anim.Play("BirdFly");

            }
            
            
            
        }
        
        
        
    }
}
