using UnityEngine;

/*  ASSET NAME: Playing Card UI Elements | Scriptable Object
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

[CreateAssetMenu (menuName = "Item/Scene/Blackjack/UI")]
public class BlackjackUIElements : ScriptableObject
{
    [Header("Placeholder Card Items to Generate")]
    public Sprite cardCanvas;
    public Sprite cardCover;

    [Header("UI Canvas")]
    public GameObject UICanvas;

    [Header("UI Container")]
    public GameObject UIContainer;

    [Header("UI Card")]
    public GameObject UICard;

    [Header("GUI Elements")]
    public GameObject standButton;
    public GameObject hitButton;

    

    [Header("Card Iconography")]
    public string iconSymbol;
    public Sprite iconSuit;
    public string cardName;
    public Canvas canvas;
    public GameObject prefabPlayerSpawn;
    public GameObject prefabDealerSpawn;
    

    
}
