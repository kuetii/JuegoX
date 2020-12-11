using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    int score = 0;
    public Text textScore;
    public GameObject Estrella;


    public int vida;
    public GameObject[] TablaDeVida;
    public float cdNoDamage;
    float currrentNoDamageCD;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        textScore.text = "Score:" + score;

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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Estrella"))
        {
            Destroy(collision.gameObject);
            SumScore(100);
        }
        if (collision.gameObject.CompareTag("Regalo"))
        {
            Destroy(collision.gameObject);
            Instantiate(Estrella, collision.gameObject.transform.position, Estrella.transform.rotation);
        }
        if (collision.gameObject.CompareTag("BastonNavidad"))
        {
            Destroy(collision.gameObject);
            SumScore(10);
        }
        if (collision.gameObject.CompareTag("Abismo"))
        {
            Destroy(collision.gameObject);
            PerderVida(1);
        }
    }
    public void SumScore(int scoreToSum)
    {
        score = score + scoreToSum;
        textScore.text = "Score: " + score;
    }

  
    
    
    void PerderVida(int damage)
    {
        {
            if (currrentNoDamageCD <= 0)
            {
                vida = vida - damage;
                currrentNoDamageCD = cdNoDamage;
            }

            if (vida <= 0)
            {
                Destroy(gameObject);
            }

        }
    }
}






