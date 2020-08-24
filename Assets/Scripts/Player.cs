using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpd;
    [SerializeField] Vector2 dir;

    public static Player playinstance;

    public Health health;

    //Dissolve Effect
    Material material;
    float fade = 1f;
    bool isDissolving;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        material = GetComponent<SpriteRenderer>().material;

        playinstance = this;
        
    }

    void Start()
    {
        Health.PlayerDead = false;
    }

    void Update()
    {
        DirInput();
        if (isDissolving)
        {
            fade -= Time.deltaTime;
            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
            }
        }

        PlayerDeath();
    }

    void LateUpdate()
    {
        Movement();
    }

    void DirInput()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");
        moveSpd = Mathf.Clamp(dir.magnitude, 0.0f, 1.0f);
        dir.Normalize();
    }

    void Movement()
    {
        rb.velocity = dir * moveSpd;

        
        if (dir.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (dir.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (dir.x > 0 && dir.y > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (dir.x < 0 && dir.y > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (dir.x > 0 && dir.y < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (dir.x < 0 && dir.y < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        

    }

    void PlayerDeath()
    {
        if (Health.PlayerDead == true)
        {
            isDissolving = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            material.SetFloat("_Fade", fade);
            //Health.PlayerDead = false;
        
        }
    }

}
