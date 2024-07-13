using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireBullet : MonoBehaviour
{

    private float speed = 10f;
    private Animator anim;
    private bool canMove;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisableBullet(5f));
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(canMove){
            Vector3 temp = transform.position;

            temp.x += speed * Time.deltaTime;
            transform.position = temp;



        }
    }
    

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;

        }
        
        
    }

    IEnumerator DisableBullet(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);


    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == MyTags.Beetle_tag || target.gameObject.tag == MyTags.SNAIL_tag)
        {
          // anim.Play("Explode");
           canMove = false;
           StartCoroutine(DisableBullet(0.1f));
        }
    }
}
