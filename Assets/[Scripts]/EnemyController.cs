/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: EnemyController.cs
 Last Modified: October 20th, 2021
 Description: Controls the motion and behaviour of the enemies
 Version History: v1.02 - Changed direction, rotation and also added internal documents along with some function/variable descriptions
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Public variables to determine the movement restrictions of the enemy
    public float verticalSpeed;
    public float verticalBoundary;
    public float direction;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        //Moves the enemy at a constant speed in the y direction/vertical
        transform.position += new Vector3(0.0f, verticalSpeed * direction * Time.deltaTime, 0.0f);
    }

    private void _CheckBounds()
    {
        // check top boundary
        if (transform.position.y >= verticalBoundary)
        {                      
            direction = -1.0f; 
        }                      
                               
        // check bottom boundary 
        if (transform.position.y <= -verticalBoundary)
        {
            direction = 1.0f;
        }
    }
}
