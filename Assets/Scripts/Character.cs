using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    int playerHealth = 3;
    public float playerSpeed = 5.5f;
    private SpriteRenderer spriteRenderer;
    float horizontal;
    private Rigidbody2D rBody;
    public float jumpForce = 3f;
    private GroundSensor sensor;
    public Animator anim;

    GameManager gameManager;
    SFXManager sfxManager;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        rBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        playerHealth = 10;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameOver == false)
        {
            horizontal = Input.GetAxis("Horizontal");

            //transform.position += new Vector3(horizontal,0,0) * playerSpeed * Time.deltaTime;

            if(horizontal < 0)
            {
                //spriteRenderer.flipX = true;
                transform.rotation = Quaternion.Euler(0,180,0);
                anim.SetBool("IsRunning", true);
            }
            else if(horizontal > 0)
            {
                //spriteRenderer.flipX = false;
                transform.rotation = Quaternion.Euler(0,0,0);
                anim.SetBool("IsRunning", true);
            }
            else
            {
                anim.SetBool("IsRunning", false);
            }

            if(Input.GetButtonDown("Jump") && sensor.isGrounded)
            {
                rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetBool("IsJumping", true);
            }
            if(Input.GetKeyDown(KeyCode.F) && gameManager.powerUpBullets > 0)
            {
                Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                gameManager.ShootPowerUp();
            } 
        }
    }

    void FixedUpdate() 
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);    
    }


    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "PowerUP")
        {
            gameManager.Reload();
            Destroy(collision.gameObject);
            sfxManager.GetGun();
        }
    }
}