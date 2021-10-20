/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: BulletType.cs
 Last Modified: October 20th, 2021
 Description: Determines the types of the creatable/spawnable bullet
 Version History: v1.01 - Unchanged functionality, added internal documentation
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum BulletType
{
    //Bullet types settable in the bullet prefabs and factory, to provide a more diverse attack choices
    REGULAR,
    FAT,
    PULSING,
    RANDOM
}
