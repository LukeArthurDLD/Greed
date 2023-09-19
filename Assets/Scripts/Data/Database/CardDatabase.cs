using System.Collections.Generic;
using UnityEngine;

/*  ASSET NAME: Card Database | Manager
 *  
 *  VERSION: 1.01
 *      1.01 (2021.11.02) | AUTHOR: T. Smith
 *      1.01 (2021.11.03) | AUTHOR: T. Smith
 *      
 *  DESCRIPTION
 *  
 *      Manages Card Items
 *  
 *      Scriptable Parameters:
 *      - Playing Cards
 */

[CreateAssetMenu(menuName = "Database/Cards")]
public class CardDatabase : ScriptableObject
{
    [Header("Card Decks")]
    public List<PlayingCard> playingCardsDeck = new List<PlayingCard>();
}
