using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public GameObject deathScreen;
    public GameObject generatorPlatform;
    public GameObject generatorBG;

    public int enemyLayer;
    public int playerLayer;

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D playerRigidBody;

    private bool grounded;
    private bool damaged;
    private bool playerDead;

    public LayerMask deathBar;
    public LayerMask whatIsGround;

    private int showDeath = 1;
    private int health;

    private Collider2D playerCollider;

    private Animator animControl;



    // Start is called before the first frame update
    void Start()
    { 
        if (DeathMenu.continueTrue == false) {
            Time.timeScale = 1;
        }

        health = this.GetComponent<Hearts>().CurrentHealth;

        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();

        animControl = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        playerRigidBody.velocity = new Vector2(moveSpeed, playerRigidBody.velocity.y);

        grounded = Physics2D.IsTouchingLayers(playerCollider, whatIsGround);
        playerDead = Physics2D.IsTouchingLayers(playerCollider, deathBar) || (health == 0);


        if (grounded && Input.GetKeyDown(KeyCode.Space))                    //(Input.GetMouseButtonDown(0)))
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce + 1000000000);
        }


        animControl.SetBool("Grounded", grounded);
        animControl.SetBool("Damaged", damaged);


        if ((playerDead) && (showDeath < 5))
        {
            moveSpeed = 0;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            deathScreen.GetComponent<DeathMenu>().Show();
            showDeath = 20;
        }
    }

    public void Jump()
    {
        if (grounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce + 1000000000);
        }
    }

    void Hurt()
    {
        this.GetComponent<Hearts>().CurrentHealth--;
        health--;
    }

    public IEnumerator HurtAnim()
    {
              enemyLayer = LayerMask.NameToLayer("Enemy");
     playerLayer = LayerMask.NameToLayer("Player");
    Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer);

        animControl.SetLayerWeight(1, 1);

        damaged = true;

        yield return new WaitForSeconds(3);

        animControl.SetLayerWeight(1, 0);
        damaged = false;

        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();

        if (enemy != null)
        {
            StartCoroutine(HurtAnim());
            Hurt();
        }
    }

    public void ResetVar()
    {
       // grounded = false;
        damaged = false;
        playerDead = false;
        showDeath = 1;
        health = 5;
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
    }

}

