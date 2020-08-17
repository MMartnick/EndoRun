using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{

    public int health = 1;
    public Rigidbody2D enemyRb;
    public GameObject impactEffect;
    private bool enemyLoop;
    private Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        enemyLoop = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            this.transform.position = new Vector3(transform.position.x - 7, transform.position.y, transform.position.z);
          //  currentPos = this.transform.position;

        }
        else if (Time.timeScale == 0)
        {
           // this.transform.position = currentPos;
        }

        if (enemyLoop)
        {
            StartCoroutine(Behaviour());
        }
    }




    public void TakeDamage(int Damage)
    {
        health -= Damage;

        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        ScoringSystem.updateScore = 1;
    }

    IEnumerator Behaviour()
    {
        enemyLoop = false;

        float plus = 500f;
        float minus = -500f;

        enemyRb.velocity = new Vector2(plus, enemyRb.velocity.x);
        yield return new WaitForSeconds(1);
        enemyRb.velocity = new Vector2(minus, enemyRb.velocity.x);
        yield return new WaitForSeconds(1);

        enemyLoop = true;
    }



}
