using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator anim;
    public float moveSpeed;
    public Rigidbody2D rb;
    public float jumpSpeed;
    private bool faceRight = true; 


	
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	 
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up*jumpSpeed);
        }
        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * moveSpeed * Time.deltaTime);

       
        if(moveX > 0 && !faceRight)
        {
            
            flip();
        }
       
        if (moveX < 0 && faceRight)
        {
            
            flip();
        }
        if(moveX < 0|| moveX > 0)
        {
            anim.SetBool("Walk",true);
        }
        else
        {
            anim.SetBool("Walk",false);
        }


    }
    void flip() {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z); 
    }
}
