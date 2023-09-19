using UnityEngine;

/*  /*  ASSET NAME: Blackjack Game System | Manager
 *  
 *  VERSION: 1.01
 *      1.01 (2021.11.02) | AUTHOR: T. Smith
 *      1.01 (2021.11.03) | AUTHOR: T. Smith
 *  
 *      DESCRIPTION
 *  
 *      Scriptable Object for Sourcing Data
 *  
 *      Scriptable Parameters:
 *      - Scene Database
 *      - Card Database
 *      - Weapon Database
 *      - Modifier Database
 */

[CreateAssetMenu(fileName = "New Data Source", menuName = "Global/Data Source")]
public class DataSource : ScriptableObject
{
    [Header("Databases")]
    public CardDatabase scenesDatabase;
    public CardDatabase cardsDatabase;
    public WeaponDatabase weaponsDatabase;
    public ModifierDatabase modifierDatabase;
}
