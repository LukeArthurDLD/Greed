using UnityEngine;
using UnityEngine.SceneManagement;
/*  ASSET NAME: Blackjack Game System | Manager
 *  
 *  VERSION: 1.01
 *      1.01 (2021.11.02) | AUTHOR: T. Smith
 *      1.01 (2021.11.03) | AUTHOR: T. Smith
 */

public class BlackjackGameSystem : MonoBehaviour
{
    /* - - - - - - - - - - - - - - - EXTENSIONS - - - - - - - - - - - - - - - - */
    
    [Header("Parent - Blackjack Minigame | Game Manager")][SerializeField]
    internal BlackjackMinigame blackjackMinigameGameManager;

    [Header("Child - Blackjack Game System | Basic Rules")][SerializeField]
    internal BlackjackGameBasicRules basicRules;

    [Header("Child - Blackjack Game System | Advanced Rules")][SerializeField]
    internal BlackjackGameAdvancedRules advancedRules;

    /* - - - - - - - - - - - - - - - - - FUNCTIONALITY - - - - - - - - - - - - - */

    void Start()
    {
        /* DEBUG */
        Debug.Log("Blackjack Game System | Manager");
    }

    internal void CalculateValueOfCards()
    {
        // Reset - Players Hand
        blackjackMinigameGameManager.playersHand = 0;

        // Reset - Dealers Hand
        blackjackMinigameGameManager.dealersHand = 0;

        // Equate - Total Value of Players Cards
        foreach (PlayingCard c in blackjackMinigameGameManager.playersCards)
        {
            // Add - Value of Card to Players Hand
            blackjackMinigameGameManager.playersHand += c.cardValue;
        }

        // Equate - Total Value of Dealers Cards
        foreach (PlayingCard c in blackjackMinigameGameManager.dealersCards)
        {
            // Add - Value of Card to Dealers Hand
            blackjackMinigameGameManager.dealersHand += c.cardValue;
        }

        // Check - If Player's Turn
        if (blackjackMinigameGameManager.playersTurn == true)
        {
            // Minus - Value of Dealers First Card from Dealer's Hand
            blackjackMinigameGameManager.dealersHand -= blackjackMinigameGameManager.dealersCards[0].cardValue;
        }
    }

    internal void DealersTurn()
    {
        // Check - If Dealers Stands
        if (blackjackMinigameGameManager.dealersHand >= 15)
        {
            // Check - If Dealer Risks
            if ((blackjackMinigameGameManager.dealersHand < 17) && (blackjackMinigameGameManager.playersHand < 20))
            {
                // Hit - Dealer
                basicRules.Hit();
            }
            // Else - Dealer Stands
            else
            {
                // End - Dealers Turn
                blackjackMinigameGameManager.dealersTurn = false;
            }
        }
        // Else - Dealer Continues Turn
        else
        {
            // Hit - Dealer
            basicRules.Hit();
        }

        // CalculateValueOfCards();
    }
}
