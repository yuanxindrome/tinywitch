using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrgeEnemy : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 3f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = Player.playinstance.transform;

    }

    void Update()
    {
        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        movement = dir;

    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * moveSpeed * Time.deltaTime));

        if (dir.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (dir.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (dir.x > 0 && dir.y > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (dir.x < 0 && dir.y > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (dir.x > 0 && dir.y < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (dir.x < 0 && dir.y < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("GameManager").GetComponent<Health>().health -= 1;
        }

        if (Health.PlayerDead == true)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

    }



}
