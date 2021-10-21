/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: PlayerController.cs
 Last Modified: October 20th, 2021
 Description: Controls the player ship that fires bullets at the enemies
 Version History: v1.03 - Got rid of keyboard input. Changed direction, rotation, position and movement axis of the player ship. Also added internal headers along with some function/variable descriptions
 */

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public bullet manager variable for player to use to spawn bullets
    public BulletManager bulletManager;

    //Boundary for the player's movement limits
    [Header("Boundary Check")]
    public float verticalBoundary;

    //Player movement variables
    [Header("Player Speed")]
    public float verticalSpeed;
    public float maxSpeed;
    public float verticalTValue;

    //Delay for each bullet fire
    [Header("Bullet Firing")]
    public int fireFrameDelay;

    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;

    // Start is called before the first frame update
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireBullet();
    }

     private void _FireBullet()
    {
        // delay bullet firing 
        if(Time.frameCount % fireFrameDelay == 0 && bulletManager.HasBullets())
        {
            bulletManager.GetBullet(transform.position);
        }
    }

    private void _Move()
    {
        //Player movement function supported by touch inputs
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.y > transform.position.y)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.y < transform.position.y)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        //After knowing where the input is in the game world values, it applies the change in position or velocity depending on the y-value of the touch input.
        if (m_touchesEnded.y != 0.0f)
        {
           transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, m_touchesEnded.y, verticalTValue));
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(0.0f, direction * verticalSpeed);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    private void _CheckBounds()
    {
        // check top bounds
        if (transform.position.y >= verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, verticalBoundary, 0.0f);
        }

        // check bottom bounds
        if (transform.position.y <= -verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, -verticalBoundary, 0.0f);
        }

    }
}
