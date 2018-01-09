using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed;
    private Rigidbody2D myRigidbody;

    public float jumpSpeed;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;
    private Animator myAnim;




	// Use this for initialization
	void Start () {
        myAnim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (isGrounded)
        {
            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
                myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
            }
            else
            {
                myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
            }
            if (Input.GetButtonDown("Jump") && isGrounded)
            {

                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
            }
            if (isGrounded)
            {

            }
            myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
            myAnim.SetBool("Grounded", isGrounded);
        }
        
	}
}
