using UnityEngine;

/*  ASSET NAME: Blackjack Game System | Basic Rules
 *  
 *  VERSION: 1.01
 *      1.01 (2021.11.02) | AUTHOR: T. Smith
 *      1.01 (2021.11.03) | AUTHOR: T. Smith
 */

public class BlackjackGameBasicRules : MonoBehaviour
{
    /* - - - - - - - - - - - - - - - EXTENSIONS - - - - - - - - - - - - - - - - */

    [Header("Parent - Blackjack Game System | Manager")][SerializeField]
    internal BlackjackGameSystem systemManager;

    /* - - - - - - - - - - - - - - - - - FUNCTIONALITY - - - - - - - - - - - - - */

    void Start()
    {
        /* DEBUG */
        Debug.Log("Blackjack Game System | Basic Rules");
    }

    public void Hit()
    {
        // Draw - Card from Card Deck
        systemManager.blackjackMinigameGameManager.cardGameSystem.deckOperations.DrawCard();

        // Check - If Players Turn
        if (systemManager.blackjackMinigameGameManager.playersTurn == true)
        {
            // Add - Card to Players Cards
            systemManager.blackjackMinigameGameManager.playersCards.Add(systemManager.blackjackMinigameGameManager.cardToBeDrawn);
        }
        // Else - Dealers Turn
        else
        {
            // Add - Card to Dealers Cards
            systemManager.blackjackMinigameGameManager.dealersCards.Add(systemManager.blackjackMinigameGameManager.cardToBeDrawn);
        }

        // Construct - Hand
        systemManager.blackjackMinigameGameManager.blackjackUISystem.ConstructHand();
    }

    public void Stand()
    {
        // End - Players Turn
        systemManager.blackjackMinigameGameManager.playersTurn = false;

        // Start - Dealers Turn
        systemManager.blackjackMinigameGameManager.dealersTurn = true;
    }

    internal void PlayerBusted()
    {
        // Enable - Player Loss Condition
        systemManager.blackjackMinigameGameManager.playerLoss = true;

        // Enable - Round End
        systemManager.blackjackMinigameGameManager.roundEnd = true;
    }

    internal void DealerBusted()
    {
        // Enable - Dealer Loss Condition
        systemManager.blackjackMinigameGameManager.dealerLoss = true;

        // Enable - Round End
        systemManager.blackjackMinigameGameManager.roundEnd = true;
    }
}
