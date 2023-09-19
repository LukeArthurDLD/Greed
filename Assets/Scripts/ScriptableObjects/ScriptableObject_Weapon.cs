using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  ASSET DESCRIPTION
 *  
 *  Scriptable Object for Weapons
 *  
 *  Scriptable Parameters:
 *      - 3D Model
 *      - Name
 *      - Type
 *      - Suit
 *      - Animation
 */

[CreateAssetMenu(fileName = "New Weapon", menuName = "Scriptable Object/Weapon")]
public class ScriptableObject_Weapon : ScriptableObject
{
    [Header("Object Model")]
    public GameObject prefab;

    [Header("Object Description")]
    public new string name;
    public string type;
    public string suit;

    [Header("Weapon Statistics")]
    public int damage;
    public int ammo;
    public int firingRate;

    //[Header("Animations")]
}
