using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  ASSET DESCRIPTION
 *  
 *  Scriptable Object for CDs
 *  
 *  Scriptable Parameters:
 *      - Background Music
 *      - Sound FX
 */

[CreateAssetMenu(fileName = "New CD", menuName = "Scriptable Object/CD Blackjack")]
public class CD_Blackjack : ScriptableObject
{
    [Header("Background Music")]
    public AudioClip backgroundMusic;

    [Header("Character Sound FX")]
    public AudioClip[] footsteps;

    [Header("UI Sound FX")]

    public AudioClip shufflingDeck;

    public AudioClip dealingCard;
    public AudioClip placingCard;
    public AudioClip drawingCard;
    public AudioClip flippingCard;

    public AudioClip endTurn;
    public AudioClip endGame;

    public AudioClip winningGame;
    public AudioClip losingGame;
    public AudioClip drawingGame;

    public AudioClip congratulationsFanfare;

    public AudioClip speedBoostAnnouncement;
    public AudioClip healthBoostAnnouncement;
    public AudioClip damageBoostAnnouncement;
    
    public AudioClip speedPenaltyAnnouncement;
    public AudioClip healthPenaltyAnnouncement;
    public AudioClip damagePenaltyAnnouncement;

    //[Header("Environment Sound FX")]

    //[Header("Prop Sound FX")]
}
