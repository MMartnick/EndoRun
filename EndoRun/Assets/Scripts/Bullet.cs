using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5000;
    public int damage = 1;
    public Rigidbody2D bulletRigidBody;



    // Start is called before the first frame update
    void Start()
    {

        bulletRigidBody.velocity = new Vector2(speed, bulletRigidBody.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        // bulletRigidBody.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {

            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }


        GroundScript anyObject = hitInfo.GetComponent<GroundScript>();
        if (anyObject != null)
        {
            Destroy(gameObject);
        }

    }
}


