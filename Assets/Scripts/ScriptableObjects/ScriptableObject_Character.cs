using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  ASSET DESCRIPTION
 *  
 *  Scriptable Object for Characters
 *  
 *  Scriptable Parameters:
 *      - 3D Model
 *      - Name
 *      - Type
 *      - Suit
 *      - Value
 */

[CreateAssetMenu(fileName = "New Character", menuName = "Scriptable Object/Character")]
public class ScriptableObject_Character : ScriptableObject
{
    [Header("Object Model")]
    public GameObject prefab;

    [Header("Object Description")]
    public new string name;
    public string type;

    [Header("Character Statistics")]
    public float health;
    public int movementSpeed;

    [Header("Animations")]
    public Animation animation_x;
}
