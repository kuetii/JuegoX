using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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


    public float maxX;
    public float minX;
    public float cdMax;
    public float current;
    public GameObject Bullet;
    public GameObject SitioDeSpawn;
    public bool PowerupActivo = false;
    public bool Stun = false;
    public float CDPowerup;
    public float CDPowerupMax;
    public float CDstun;
    public float CDstunMax;



    float currentTime = 0f;
    float startingTime = 60f;
    [SerializeField] Text countdownText;
    public bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        rb = GetComponent<Rigidbody2D>();
        textScore.text = "Score:" + score;

    }

    // Update is called once per frame
    void Update()
    {
        if (playing == true)
        {
            if (currentTime <= 0)
            {
                SceneManager.LoadScene(2);
            }
            currentTime -= 1 * Time.deltaTime;
            current -= Time.deltaTime;
            //Jump Movent//
            if (Stun == true)
            {
                movenInput = 0;
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
                movenInput = Input.GetAxisRaw("HorizontalP1");
                if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = Vector2.up * jumpForce;
                    isJumping = true;
                    jumpTimeCounter = jumpTime;
                }
                if (transform.position.x > maxX)
                {
                    transform.position = new Vector3(minX, transform.position.y, transform.position.z);
                }
                if (transform.position.x < minX)
                {
                    transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
                }
            }

            rb.velocity = new Vector2(movenInput * speed, rb.velocity.y);

            isGrounded = Physics2D.OverlapCircle(feetPos.position, CheckRadius, whatIsGround);
            if (CDPowerup >= 0)
            {
                CDPowerup -= Time.deltaTime;
            }
            else
            {
                PowerupActivo = false;
            }
            //Spawn Bullet
            /* if (Input.GetKeyDown(KeyCode.R) && current <= 0)
             {
                 current = cdMax;
              GameObject BalaTemporal = Instantiate(Bullet,SitioDeSpawn.transform.position, Bullet.transform.rotation);

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
             }
             */
            //Gira el sprite
            if (movenInput > 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (movenInput < 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
            //Jump


        }
    }
    //puntuacion,PerdervidasAbismo 
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

            PerderVida(1);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PowerupActivo == true)
            {
                collision.gameObject.GetComponent<Player2Movent>().Stun = true;
                collision.gameObject.GetComponent<Player2Movent>().CDstun = CDstunMax;
            }
        }
    }

    public void SumScore(int scoreToSum)
    {
        score = score + scoreToSum;
        textScore.text = "Score: " + score;
    }



    //vidas
    void PerderVida(int damage)
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

        ContadorVidas();
    }
    void ContadorVidas()
    {
        for (int i = 0; i < TablaDeVida.Length; i++)
        {
            TablaDeVida[i].SetActive(false);
        }
        for (int i = 0; i < vida; i++)
        {
            TablaDeVida[i].SetActive(true);
        }
    }

}










