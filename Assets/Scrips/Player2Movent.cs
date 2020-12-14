using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movent : MonoBehaviour
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
    public float minX;
    public float maxX;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < maxX)
        {
            transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > minX)
        {
            transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        }
        isGrounded = Physics2D.OverlapCircle(feetPos.position, CheckRadius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }

    }  s
    
}