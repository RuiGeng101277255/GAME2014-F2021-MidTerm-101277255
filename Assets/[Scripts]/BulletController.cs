/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: BulletController.cs
 Last Modified: October 20th, 2021
 Description: Controls the behaviour of the bullets
 Version History: v1.02 - Changed direction, rotation and also added internal document along with some function/variable descriptions
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IApplyDamage
{
    //Public variables that determine the motion of the bullet, the manager responsible for the bullet and the damage it can inflict on enemies/player
    public float horixontSpeed;
    public float horizontalBoundary;
    public BulletManager bulletManager;
    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        //Finds any existing bulletmanager
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        //Bullet moves along the horizontal direction (left to right) in a fixed speed
        transform.position += new Vector3(horixontSpeed, 0.0f, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        //Checks if the bullet has gone beyond the boundary, if so, then return the bullet to the pool to be reused later
        if (transform.position.x > horizontalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Returns this particular bullet to the manager
        bulletManager.ReturnBullet(gameObject);
    }

    public int ApplyDamage()
    {
        //The damage the bullet can inflict whether on player and/or enemies
        return damage;
    }
}
