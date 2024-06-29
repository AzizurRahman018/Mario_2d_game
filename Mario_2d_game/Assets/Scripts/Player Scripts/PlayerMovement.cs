using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{



    public float speed = 5f;

    private Rigidbody2D myBody;
    private Animator anim;


    public Transform groundCheckPosition;
    public LayerMask groundLayer;
    void Awake(){
    myBody = GetComponent<Rigidbody2D> ();
    anim = GetComponent<Animator> () ;



    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.5f,groundLayer))
        {
            print("Collided with ground");
        }
    }

    void FixedUpdate()
    {
        PlayerWalk();
       
    }
    void PlayerWalk(){
            float h = Input.GetAxisRaw("Horizontal");
            // print("valu is " + h );

          if (h>0)
          {
                myBody.velocity =  new Vector2 ( speed ,myBody.velocity.y);
                //speed is x and velocity.y is y 
                //go to right side 
                ChangeDirection(1);
          } else if (h<0){
                myBody.velocity =  new Vector2 ( -speed ,myBody.velocity.y);
                //go to left side 
                ChangeDirection(-1);


          } else{

            myBody.velocity= new Vector2(0f,myBody.velocity.y);

          }
          anim.SetInteger ("Speed", Mathf.Abs((int)myBody.velocity.x));
    }

    void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;



    }

    void OnCollisionEnter2D(Collision2D target)
    {
        //
        // if (target.gameObject.tag == "Ground")
        // {
        //
        //     print("collided with Ground");
        //
        //
        // }

    }
     //Other way
    void OnTriggerEnter2D(Collider2D target)
    {

        // if (target.tag == "Ground")
        // {
        //     print("Collided with tag");
        //
        //
        //
        // }
        
        
        
    }

}
