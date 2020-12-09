using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovent : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    private float movenInput;
    public float jumpForce;

    private bool isGrounded;
    public Transform feetPos;
    public float CheckRadius;
    public LayerMask whatIsGround;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jump Movent//
        movenInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movenInput * speed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(feetPos.position, CheckRadius, whatIsGround);


        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }
        if (Input.GetKey(KeyCode.Space)&& isJumping == true){
            
        {
                if (jumpTimeCounter >0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
        }
            if (Input.GetKeyUp(KeyCode.Space))
             {
                isJumping = false;

            }
        }
    }
}
