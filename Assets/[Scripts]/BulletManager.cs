/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: BulletManager.cs
 Last Modified: October 20th, 2021
 Description: Controls the usage of bullets and contains a bullet pool
 Version History: v1.01 - Unchanged functionality, added internal documentation and descriptions.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    //Takes a public bullet factory for the creation of bullets along with max bullet count, used for the bulletpool
    public BulletFactory bulletFactory;
    public int MaxBullets;

    private Queue<GameObject> m_bulletPool;


    // Start is called before the first frame update
    void Start()
    {
        _BuildBulletPool();
    }

    private void _BuildBulletPool()
    {
        // create empty Queue structure
        m_bulletPool = new Queue<GameObject>();

        //Initial pool
        for (int count = 0; count < MaxBullets; count++)
        {
            var tempBullet = bulletFactory.createBullet();
            m_bulletPool.Enqueue(tempBullet);
        }
    }

    public GameObject GetBullet(Vector3 position)
    {
        //Gets a bullet for it to be used in game
        var newBullet = m_bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    public bool HasBullets()
    {
        //Checks if there is any available bullet
        return m_bulletPool.Count > 0;
    }

    public void ReturnBullet(GameObject returnedBullet)
    {
        //Adds the returned bullet back to the queue/pool so it can be reused later
        returnedBullet.SetActive(false);
        m_bulletPool.Enqueue(returnedBullet);
    }
}
