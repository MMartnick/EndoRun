using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D playerRigidBody;

    public bool grounded;
    public LayerMask whatIsGround;
    public bool playerDead;
    public int touchRed = 1;
    public LayerMask deathBar;
    public GameObject deathScreen;
    public GameObject generator;
    public GameObject generatorBG;

    private Collider2D playerCollider;

    private Animator movement;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();

        movement = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        playerRigidBody.velocity = new Vector2(moveSpeed, playerRigidBody.velocity.y);

        grounded = Physics2D.IsTouchingLayers(playerCollider, whatIsGround);
        playerDead = Physics2D.IsTouchingLayers(playerCollider, deathBar);


        if (grounded && Input.GetKeyDown(KeyCode.Space))                    //(Input.GetMouseButtonDown(0)))
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce + 1000000000);
        }


        movement.SetBool("Grounded", grounded);


        if ((playerDead) && (touchRed < 5))
        {
            moveSpeed = 0;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            deathScreen.GetComponent<DeathMenu>().Show();
            touchRed = 20;
        }
    }

    public void Jump()
    {
        if (grounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce + 1000000000);
        }
    }
}

