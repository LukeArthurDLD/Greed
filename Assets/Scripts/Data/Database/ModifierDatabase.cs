using System.Collections.Generic;
using UnityEngine;

/*  ASSET NAME: Modifier Database | Manager
 *  
 *  VERSION: 1.01
 *      1.01 (2021.11.02) | AUTHOR: T. Smith
 *      1.01 (2021.11.03) | AUTHOR: T. Smith
 *      
 *  DESCRIPTION
 *  
 *      Manages Modifier Items
 *  
 *      Scriptable Parameters:
 *      - Sidearms
 *      - Shotguns
 *      - Sub Machine Guns
 */

[CreateAssetMenu(menuName = "Database/Modifiers")]
public class ModifierDatabase : ScriptableObject
{
    [Header("Positive Modifiers")]
    public List<Modifier> positiveModifiers = new List<Modifier>();

    [Header("Negative Modifiers")]
    public List<Modifier> negativeModifiers = new List<Modifier>();
}
