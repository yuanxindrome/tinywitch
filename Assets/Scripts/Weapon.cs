using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //For Weapon
    public GameObject player;
    public float offset;

    //For Fireball
    public GameObject fireball;
    public Transform firepoint;

    //Timer for Shots
    private float timeBtwShots;
    public float startTimeBtwShots;

    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + offset);

        if (rotationZ < -90 || rotationZ > 90)
        {
            if (player.transform.position.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }
            else if (player.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }
        }
    }

    private void Update()
    {
        ShootFire();
    }

    private void ShootFire()
    {
        if (Health.PlayerDead == true)
        {
            //Do nothing
        }
        else
        {
            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(fireball, firepoint.position, transform.rotation);
                    timeBtwShots = startTimeBtwShots;
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}
