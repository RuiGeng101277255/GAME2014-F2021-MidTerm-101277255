/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: BulletFactory.cs
 Last Modified: October 20th, 2021
 Description: Controls the fabrication of bullets
 Version History: v1.01 - script functionality unchanged, added internal document and some descriptions
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletFactory : MonoBehaviour
{
    //Public variables that takes different types of bullet prefabs to be created later
    [Header("Bullet Types")]
    public GameObject regularBullet;
    public GameObject fatBullet;
    public GameObject pulsingBullet;

    //Creates bullet based on the bullet type, if nothing is especified then the type is random.
    public GameObject createBullet(BulletType type = BulletType.RANDOM)
    {
        if (type == BulletType.RANDOM)
        {
            var randomBullet = Random.Range(0, 3);
            type = (BulletType) randomBullet;
        }

        GameObject tempBullet = null;

        //Damages of different types of bullets
        switch (type)
        {
            case BulletType.REGULAR:
                tempBullet = Instantiate(regularBullet);
                tempBullet.GetComponent<BulletController>().damage = 10;
                break;
            case BulletType.FAT:
                tempBullet = Instantiate(fatBullet);
                tempBullet.GetComponent<BulletController>().damage = 20;
                break;
            case BulletType.PULSING:
                tempBullet = Instantiate(pulsingBullet);
                tempBullet.GetComponent<BulletController>().damage = 30;
                break;
        }

        //Sets up bullet so it can be used and/or reused in the bullet manager
        tempBullet.transform.parent = transform;
        tempBullet.SetActive(false);

        return tempBullet;
    }
}
