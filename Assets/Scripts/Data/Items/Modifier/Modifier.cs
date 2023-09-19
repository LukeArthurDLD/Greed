using UnityEngine;

/*  ASSET NAME: Modifier | Scriptable Object
 *  
 *  VERSION: 1.00
 *      1.00 (2021.11.03) | AUTHOR: T. Smith
 *  
 *  DESCRIPTION
 *  
 *      Scriptable Object for 'Modifier' Items
 *  
 *      Scriptable Parameters:
 *      - Modifier Details
 *      - Modifier Artwork
 */

[CreateAssetMenu(fileName = "New Modifier", menuName = "Item/Modifier")]
public class Modifier : ScriptableObject
{
    [Header("Modifier Details")]
    public string modifierName;
    public string modifierCategory;
    public string modifierType;
    public float modifierMultiplier;

    [Header("Modifier Artwork")]
    public Sprite modifierCategoryIcon;
    public Sprite modifierTypeIcon;
}
