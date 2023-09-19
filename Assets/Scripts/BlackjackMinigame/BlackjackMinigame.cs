using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*  ASSET NAME: Blackjack Minigame | Manager
   
    VERSION: 1.01
       1.01 (2021.11.02) | AUTHOR: T. Smith
       1.01 (2021.11.03) | AUTHOR: T. Smith
 */

public class BlackjackMinigame : MonoBehaviour
{
    // - - - - - - - - - - - - - - - EXTENSIONS - - - - - - - - - - - - - - - - 

    [Header("Data Source")][SerializeField]
    internal DataSource dataSource;

    [Header("Card Game System")][SerializeField]
    internal CardGameSystem cardGameSystem;

    [Header("Blackjack Game System")][SerializeField]
    internal BlackjackGameSystem blackjackGameSystem;

    [Header("Blackjack UI System")][SerializeField]
    internal BlackjackUISystem blackjackUISystem;

    [Header("Gameplay Modifier System")][SerializeField]
    // internal GameplayModifierSystem gameplayModifierSystem;

    // - - - - - - - - - - - - - - BLACK JACK GAME VARIABLES - - - - - - - - - - - - - - - -

    [Header("Blackjack Card Deck")]
    public List<PlayingCard> cardDeck = new List<PlayingCard>();
    internal PlayingCard cardToBeDrawn;

    [Header("Player's Hand")]
    public List<PlayingCard> playersCards = new List<PlayingCard>();
    public int playersHand;

    [Header("Dealer's Hand")]
    public List<PlayingCard> dealersCards = new List<PlayingCard>();
    public int dealersHand;

    // - - - - - - - - - - - - - - GAME STATES - - - - - - - - - - - - - - - -

    // Conditional Checks - Game Progression
    internal bool playersTurn = true;
    internal bool dealersTurn = false;
    internal bool roundEnd = false;
    internal bool gameEnd = false;
    internal bool nextLevel = false;

    // Conditional Checks - Loss Condition
    internal bool playerLoss = false;
    internal bool dealerLoss = false;

    // Conditional Checks - Special Rules    
    internal bool fiveCardTrick = false;

    // Conditional Checks - Win Condition
    internal bool playerWin = false;
    internal bool dealerWin = false;
    internal bool gameDraw = false;

    // - - - - - - - - - - - - - - - - - FUNCTIONALITY - - - - - - - - - - - - - - - - 

    void Start()
    {
        /* DEBUG */
        Debug.Log("Blackjack Minigame | Manager");

        // Setup - Card Game
        SetupCardGame();

        // Construct - UI
        blackjackUISystem.ConstructHand();
    }

    void Update()  
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(1);
        }
        // Check - If Next Level
        if (nextLevel == true)
        {
            // Get - Current Scene Build Index
            int _buildIndex = SceneManager.GetActiveScene().buildIndex;

            // Load - Next Scene
            SceneManager.LoadScene(_buildIndex + 1);
        }
        // Check - If Game has Ended
        else if (gameEnd == true)
        {
            // Get - Gameplay Modifier
            // gameplayModifierSystem.ConstructModifierList();

            nextLevel = true;
        }
        // Check - If Round has Ended
        else if (roundEnd == true)
        {
            // Check - Game Win/Loss Conditions
            CheckGameWinLossConditions();
        }
        // Else - Play Blackjack Minigame
        else
        {
            // Check - Conditional Game Rules
            CheckGameConditionalRules();

            // Check - Game Progression Conditions
            CheckGameProgressionConditions();

            // Calculate - Value of Cards
            blackjackGameSystem.CalculateValueOfCards();
        }
        
    }

    internal void SetupCardGame()
    {
        // Generate - New Deck of Cards
        cardGameSystem.deckOperations.GenerateNewDeck();

        // Shuffle - Deck of Cards
        cardGameSystem.deckOperations.ShuffleDeck();

        // Deal - Cards to Player & Dealer
        cardGameSystem.deckOperations.DealCards();
    }

    internal void CheckGameConditionalRules()
    {
        // Check - If Players Hand Exceeds 21
        if (playersHand > 21)
        {
            // Bust - Player
            blackjackGameSystem.basicRules.PlayerBusted();
        }

        // Check - If Dealers Hand Exceeds 21
        if (dealersHand > 21)
        {
            // Bust - Dealer
            blackjackGameSystem.basicRules.DealerBusted();
        }

        // Check - Ace Variation Conditions
        blackjackGameSystem.advancedRules.CheckAceVariation();

        // Check - Five Card Trick Conditions
        blackjackGameSystem.advancedRules.CheckFiveCardTrick();
    }

    internal void CheckGameProgressionConditions()
    {
        // Check - If Players Turn & Dealers Turn has Ended
        if (playersTurn == false && dealersTurn == false)
        {
            // Enable - Round Ends Condition
            roundEnd = true;
            
            // Check - Game Win/Loss Conditions
            CheckGameWinLossConditions();
        }

        // Check - If Player Turn has Ended
        if (dealersTurn == true)
        {
            // Start - Dealers Turn
            blackjackGameSystem.DealersTurn();
        }
    }

    internal void CheckGameWinLossConditions()
    {
        Debug.Log("Checking Win Loss...");
        
        // Check - If Player Loses Abruptly
        if (playerLoss == true)
        {
            // Enable - Dealer Win Condition
            dealerWin = true;

            // Enable - End Game
            gameEnd = true;
        }

        // Check - If Dealer Loses Abruptly
        else if (dealerLoss == true)
        {
            // Enable - Player Win Condition
            playerWin = true;

            // Enable - End Game
            gameEnd = true;
        }

        // Check - Five Card Trick Condition
        if (fiveCardTrick == true)
        {
            // Check - If Player Wins
            if (playerWin == true)
            {
                // Enable - End Game
                gameEnd = true;
            }

            // Check - If Dealer Wins
            if (dealerWin == true)
            {
                // Enable - End Game
                gameEnd = true;
            }
        }
        
        // Check - If Round has Ended
        if (roundEnd == true)
        {
            // Compare - If Players Hand is Bigger Than Dealers Hand
            if ((playersHand > dealersHand) && (playerLoss == false))
            {
                // Enable - Player Win Condition
                playerWin = true;

                // Enable - End Game
                gameEnd = true;
            }
            // Compare - If Dealers Hand is Bigger Than Players Hand
            else if ((dealersHand > playersHand) && (dealerLoss == false))
            {
                // Enable - Dealer Win Condition
                dealerWin = true;

                // Enable - End Game
                gameEnd = true;
            }
            // Check - If Player & Dealer Draw
            else
            {
                // Enable - Game Draw Condition
                gameDraw = true;

                // Enable - End Game
                gameEnd = true;
            }
        }
    }
}
