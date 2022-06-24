using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyGameObject : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate = 0.5f;
    private float countdown = 0f;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {       
        if (countdown <= 0f && GameControl.instance.gameOver == false)
        {
            Shoot();
            countdown = 1f / fireRate;
        }

        countdown -= Time.deltaTime;
    }

    void Shoot ()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
