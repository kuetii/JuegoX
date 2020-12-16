using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Movent : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
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
    public GameObject Bullet;
    public float cdMax;
    public float current;
    public GameObject SitioDeSpawn;
    public bool PowerupActivo = false;
    public bool Stun = false;
    public float CDPowerup;
    public float CDPowerupMax;
    public float CDstun;
    public float CDstunMax;
    int score = 0;
    public Text textScore;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       textScore.text = "Score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        current -= Time.deltaTime;
        if (Stun == true)
        {
            if (CDstun >= 0)
            {
                CDstun -= Time.deltaTime;
            }
            else if (CDstun <= 0)
            {
                Stun = false;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < maxX)
            {
                transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > minX)
            {
                transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = Vector2.up * jumpForce;
                isJumping = true;
                jumpTimeCounter = jumpTime;
            }
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, CheckRadius, whatIsGround);

        if (CDPowerup >= 0)
        {
            CDPowerup -= Time.deltaTime;
        }
        else
        {
            PowerupActivo = false;
        }


    }
    /*
    if (Input.GetKeyDown(KeyCode.Keypad1) && current <= 0)
    {
        current = cdMax;
        GameObject BalaTemporal = Instantiate(Bullet, SitioDeSpawn.transform.position, Bullet.transform.rotation);

        // si miro hacia la derecha va la bala a la derecha
        if (this.GetComponent<SpriteRenderer>().flipX == false)
        {

            BalaTemporal.GetComponent<MoventBullet>().Direccion = Vector3.right;
        }
        else
        {
            BalaTemporal.GetComponent<MoventBullet>().Direccion = Vector3.left;
        }
        //si miro a la izquierda va la bala a la izquierda
    }*/
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
            PowerupActivo = true;
            CDPowerup = CDPowerupMax;
        }
        if (collision.gameObject.CompareTag("BastonNavidad"))
        {
            Destroy(collision.gameObject);
            SumScore(10);
        }
        if (collision.gameObject.CompareTag("Abismo"))
        {


        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PowerupActivo == true)
            {
                collision.gameObject.GetComponent<PlayerMovent>().Stun = true;
                collision.gameObject.GetComponent<PlayerMovent>().CDstun = CDstunMax;

            }
        }
    }
    public void SumScore(int scoreToSum)
    {
        score = score + scoreToSum;
        textScore.text = "Score: " + score;
    }







}