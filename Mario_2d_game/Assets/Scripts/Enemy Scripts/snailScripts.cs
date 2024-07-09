using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float moveSpeed = 1f;
    private Rigidbody2D myBody;
    private Animator anim;
    private bool moveLeft;

    private bool canMove;
    private bool stunned;
    public Transform down_Collision ,left_Collision,right_Collision,Top_Collision;
    private Vector3 left_Collision_Position, right_Collision_Position;
    public LayerMask playerLayer;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        left_Collision_Position = left_Collision.position;
        right_Collision_Position = right_Collision.position;

    }


    // Start is called before the first frame update
    void Start()
    {
        moveLeft = true ;
        canMove = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (moveLeft)
            {
                myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
            }
            else
            {
                myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);

            }
        }

        CheckCollision();    

    }
    
    
    
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        




    }

    void CheckCollision()
    {
        RaycastHit2D lefthit = Physics2D.Raycast(left_Collision.position, Vector2.left, 0.1f, playerLayer);
        RaycastHit2D righthit = Physics2D.Raycast(right_Collision.position, Vector2.right, 0.1f, playerLayer);

        Collider2D tophit = Physics2D.OverlapCircle(Top_Collision.position, 0.2f, playerLayer);

        if (tophit != null) {
            if (tophit.gameObject.tag == MyTags.PLAYER_TAG)
            {
                if (!stunned)
                {
                    tophit.gameObject.GetComponent<Rigidbody2D>().velocity =
                        new Vector2(tophit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 7f);
                    canMove = false;
                 
                    myBody.velocity = new Vector2(0, 0);
                    anim.Play("Stunned");
                    stunned = true ; 
                    // Beetle coode here
                   
                    
                    
                    if (tag == MyTags.Beetle_tag)
                    {
                        anim.Play("Stunned");
                        StartCoroutine(Dead());



                    }
                }
                
                
                
            }
            
            
            
            
            
        }

        if (lefthit)
        {
            if (lefthit.collider.gameObject.tag == MyTags.PLAYER_TAG)
            {
                if (!stunned)
                {
                    //Apply Damage to player
                    print("Damage left");
                    
                }
                else
                { if(tag !=MyTags.Beetle_tag)
                    {
                        myBody.velocity = new Vector2(15f, myBody.velocity.y);
                    }
                }
            }
            
            
        }

        if (righthit)
        {
            if (righthit.collider.gameObject.tag == MyTags.PLAYER_TAG)
            {
                if (!stunned)
                {
                    print("Damage Right");
                    
                }
                else
                { if(tag !=MyTags.Beetle_tag)
                    {
                        myBody.velocity = new Vector2(-15f, myBody.velocity.y);
                    }
                }
            }
            
            
            
        }
        
        
        
        
        
        
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

            left_Collision.position = left_Collision_Position;
            right_Collision.position = right_Collision_Position;
            

        }
        else
        {
            tempScale.x = -Math.Abs(tempScale.x);
            //negative valu x like -2 
            left_Collision.position = right_Collision_Position;
            right_Collision.position = left_Collision_Position;   
        }

        transform.localScale = tempScale;
    }

    // private void OnCollisionEnter2D(Collision2D target)
    // {
    //     if (target.gameObject.tag=="Player")
    //     {
    //         anim.Play("stunned");
    //     }
    // }


   
}
























