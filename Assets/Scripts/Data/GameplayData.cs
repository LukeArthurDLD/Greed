using UnityEngine;

/*  ASSET NAME: Gameplay Data | Scriptable Object
 *  
 *  VERSION: 1.00
 *      1.00 (2021.12.07) | AUTHOR: T. Smith
 *  
 *  DESCRIPTION
 *  
 *      Scriptable Object for 'Gameplay Data' Items
 *  
 *      Scriptable Parameters:
 *      - Gameplay Modifier
 */

[CreateAssetMenu(fileName = "Live Data", menuName = "Gameplay/Live Data")]
public class GameplayData : ScriptableObject
{
    [Header("Live Modifier Data")]
    public string activeModifierType;
    public float activeModifierMultiplier;
}
