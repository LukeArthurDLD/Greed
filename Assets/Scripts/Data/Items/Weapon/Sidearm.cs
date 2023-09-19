﻿using UnityEngine;

/*  ASSET NAME: Sidearm | Scriptable Object
 *  
 *  VERSION: 1.01
 *      1.01 (2021.11.02) | AUTHOR: T. Smith
 *      1.01 (2021.11.03) | AUTHOR: T. Smith
 *  
 *  DESCRIPTION
 *  
 *      Scriptable Object for 'Sidearm' Items
 *  
 *      Scriptable Parameters:
 *      - Weapon Details
 *      - Weapon Statistics
 *      - Weapon Model
 *      - User-Interface
 */

[CreateAssetMenu(fileName = "New Sidearm", menuName = "Weapon/Sidearm")]
public class Sidearm : ScriptableObject
{
    [Header("Weapon Details")]
    public string weaponName;
    public string weaponCategory;
    public string weaponType;
    public string fireType;
    public string reloadType;

    [Header("Weapon Statistics")]
    public float damageOutput;
    public float maxRange;
    public float fireRate;
    public int ammoCount;

    [Header("Weapon Model")]
    public GameObject weaponPrefab;

    [Header("User-Interface")]
    public Sprite weaponArtwork;
    public float weaponScaleX;
    public float weaponScaleY;
}
