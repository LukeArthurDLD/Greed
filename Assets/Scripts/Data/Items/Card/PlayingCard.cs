using UnityEngine;

/*  ASSET NAME: Playing Card | Scriptable Object
 *  
 *  VERSION: 1.01
 *      1.00 (2021.11.02) | AUTHOR: T. Smith
 *      1.01 (2021.11.03) | AUTHOR: T. Smith
 *  
 *  DESCRIPTION
 *  
 *      Scriptable Object for 'Playing Card' Items
 *  
 *      Scriptable Parameters:
 *      - Card Details
 *      - Card Iconography
 */

[CreateAssetMenu(fileName = "New Playing Card", menuName = "Item/Card/Playing Card")]
public class PlayingCard : ScriptableObject
{
    [Header("Card Details")]
    public string cardName;
    public string cardSuit;
    public string cardType;
    public int cardValue;

    [Header("Card Iconography")]
    public string iconSymbol;
    public Sprite iconSuit;
}
