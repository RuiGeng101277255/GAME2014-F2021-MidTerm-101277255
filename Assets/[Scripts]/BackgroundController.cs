/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: BackgroundController.cs
 Last Modified: October 20th, 2021
 Description: Controls the scrolling of the background stars
 Version History: v1.02 - Changed direction and also added internal headers along with some function/variable descriptions
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    //Public variables, changed to horizontal so it scrolls right to left
    public float horizontalSpeed;
    public float horizontalBoundary;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Reset()
    {
        //resets the position of the background
        transform.position = new Vector3(horizontalBoundary, 0.0f);
    }

    private void _Move()
    {
        //Moves background stars at a constant speed
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        // if the background is left of the negative boundary then it's reset
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }
}
