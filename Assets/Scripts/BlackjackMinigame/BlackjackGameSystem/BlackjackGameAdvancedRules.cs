using UnityEngine;

/*  ASSET NAME: Blackjack Game System | Advanced Rules
 *  
 *  VERSION: 1.01
 *      1.01 (2021.11.02) | AUTHOR: T. Smith
 *      1.01 (2021.11.03) | AUTHOR: T. Smith
 */

public class BlackjackGameAdvancedRules : MonoBehaviour
{
    /* - - - - - - - - - - - - - - - EXTENSIONS - - - - - - - - - - - - - - - - */

    [Header("Parent - Blackjack Game System | Manager")][SerializeField]
    internal BlackjackGameSystem systemManager;

    /* - - - - - - - - - - - - - - - - - FUNCTIONALITY - - - - - - - - - - - - - */

    void Start()
    {
        /* DEBUG */
        Debug.Log("Blackjack Game System | Advanced Rules");
    }

    internal void CheckAceVariation()
    {
        // Temp Holder - Hand Value
        int _tempHandValue = 0;

        // Equate - Total Value of Players Cards
        foreach (PlayingCard c in systemManager.blackjackMinigameGameManager.playersCards)
        {
            // Check - If Card in Players Hand is Ace
            if (c.cardType == "Ace")
            {
                // Reset - Value of Ace
                c.cardValue = 11;
            }

            // Add - Value of Card to Hand Value
            _tempHandValue += c.cardValue;
        }

        // Check - Players Hand for Busting
        foreach (PlayingCard c in systemManager.blackjackMinigameGameManager.playersCards)
        {
            // Check - If Card Type is Ace & Card Value is 11
            if (c.cardType == "Ace" && c.cardValue == 11)
            {
                // Check - If Player will Bust
                if (_tempHandValue > 21)
                {
                    // Adjust - Value of Ace in Players Hand
                    c.cardValue = 1;
                    _tempHandValue -= 10;
                }
            }
        }

        // Reset - Hand Value
        _tempHandValue = 0;

        // Equate - Total Value of Dealers Cards
        foreach (PlayingCard c in systemManager.blackjackMinigameGameManager.playersCards)
        {
            // Check - If Card in Dealers Hand is Ace
            if (c.cardType == "Ace")
            {
                // Reset - Value of Ace
                c.cardValue = 11;
            }

            // Add - Value of Card to Hand Value
            _tempHandValue += c.cardValue;
        }

        // Check - Dealers Hand for Busting
        foreach (PlayingCard c in systemManager.blackjackMinigameGameManager.playersCards)
        {
            // Check - If Card Type is Ace & Card Value is 11
            if (c.cardType == "Ace" && c.cardValue == 11)
            {
                // Check - If Dealer will Bust
                if (_tempHandValue > 21)
                {
                    // Adjust - Value of Ace in Dealers Hand
                    c.cardValue = 1;
                    _tempHandValue -= 10;
                }
            }
        }

        // Reset - Hand Value
        _tempHandValue = 0;

        // Calculate - Total Value of Cards in Players Hand & Dealers Hand
        systemManager.CalculateValueOfCards();
    }

    internal void CheckFiveCardTrick()
    {
        // Check - If Player has 5 Cards
        if ((systemManager.blackjackMinigameGameManager.playersCards.Count == 5) && (systemManager.blackjackMinigameGameManager.playerLoss == false))
        {
            // gameObject.SetActive(Hit Button);

            // Check - If Player Doesn't Lose
            if (systemManager.blackjackMinigameGameManager.playerLoss == false)
            {
                // Enable - Five Card Trick
                systemManager.blackjackMinigameGameManager.fiveCardTrick = true;

                // Enable - Player Win
                systemManager.blackjackMinigameGameManager.playerWin = true;
            }
        }

        // Check - If Dealer has 5 Cards
        if ((systemManager.blackjackMinigameGameManager.dealersCards.Count == 5) && (systemManager.blackjackMinigameGameManager.dealerLoss == false))
        {
            // Enable - Five Card Trick
            systemManager.blackjackMinigameGameManager.fiveCardTrick = true;

            // Enable - Dealer Win
            systemManager.blackjackMinigameGameManager.dealerWin = true;
        }
    }
}
