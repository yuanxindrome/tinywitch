using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSM : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        CameraShake.shakeCam.StartShake(0.2f, 0.04f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            DestroyProjectile();
        }
    }

}
