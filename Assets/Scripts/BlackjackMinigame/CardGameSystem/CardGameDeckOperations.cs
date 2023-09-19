using System.Collections.Generic;
using UnityEngine;

/*  ASSET NAME: Card Game System | Deck Operations
 *  
 *  VERSION: 1.01
 *      1.01 (2021.11.02) | AUTHOR: T. Smith
 *      1.01 (2021.11.03) | AUTHOR: T. Smith
 */

public class CardGameDeckOperations : MonoBehaviour
{
    /* - - - - - - - - - - - - - - - EXTENSIONS - - - - - - - - - - - - - - - - */

    [Header("Parent - Card Game System | Manager")][SerializeField]
    internal CardGameSystem systemManager;

    /* - - - - - - - - - - - - - - - - - FUNCTIONALITY - - - - - - - - - - - - - */

    void Start()
    {
        /* DEBUG */
        Debug.Log("Card Game System | Deck Operations");
    }

    internal void GenerateNewDeck()
    {
        // Source - Cards from the Card Database
        systemManager.blackjackMinigameGameManager.cardDeck = new List<PlayingCard>(systemManager.blackjackMinigameGameManager.dataSource.cardsDatabase.playingCardsDeck);
        
        // For - Every Playing Card Reset Data to Default
        for (int i = 0; i < systemManager.blackjackMinigameGameManager.cardDeck.Count; i++)
        {
            // Reset - Name
            systemManager.blackjackMinigameGameManager.cardDeck[i].name = systemManager.blackjackMinigameGameManager.dataSource.cardsDatabase.playingCardsDeck[i].cardName;                  
        }
    }
    
    internal void ShuffleDeck()
    {
        // Temp Holder - Shuffled Cards
        List<PlayingCard> _tempShuffledCards = new List<PlayingCard>();

        // Randomize - Cards in Card Deck
        for (int i = 0; i < systemManager.blackjackMinigameGameManager.cardDeck.Count;)
        {
            int _rand = Random.Range(0, systemManager.blackjackMinigameGameManager.cardDeck.Count);
            _tempShuffledCards.Add(systemManager.blackjackMinigameGameManager.cardDeck[_rand]);
            systemManager.blackjackMinigameGameManager.cardDeck.Remove(systemManager.blackjackMinigameGameManager.cardDeck[_rand]);
        }

        // Store - Shuffled Cards in the Card Deck
        systemManager.blackjackMinigameGameManager.cardDeck = new List<PlayingCard>(_tempShuffledCards);

        // Clear - Shuffled Cards
        _tempShuffledCards.Clear();
    }

    internal void DealCards()
    {
        // Draw - Four Cards from Card Deck
        for (int i = 0; i < 2; i++)
        {
            // Add - Card to Players Hand
            systemManager.blackjackMinigameGameManager.cardToBeDrawn = systemManager.blackjackMinigameGameManager.cardDeck[0];
            systemManager.blackjackMinigameGameManager.playersCards.Add(systemManager.blackjackMinigameGameManager.cardToBeDrawn);
            systemManager.blackjackMinigameGameManager.cardDeck.Remove(systemManager.blackjackMinigameGameManager.cardDeck[0]);

            // Add - Card to Dealers Hand
            systemManager.blackjackMinigameGameManager.cardToBeDrawn = systemManager.blackjackMinigameGameManager.cardDeck[0];
            systemManager.blackjackMinigameGameManager.dealersCards.Add(systemManager.blackjackMinigameGameManager.cardToBeDrawn);
            systemManager.blackjackMinigameGameManager.cardDeck.Remove(systemManager.blackjackMinigameGameManager.cardDeck[0]);
        }
    }

    internal void DrawCard()
    {
        // Add - Card to Card to be Drawn
        systemManager.blackjackMinigameGameManager.cardToBeDrawn = systemManager.blackjackMinigameGameManager.cardDeck[0];
        systemManager.blackjackMinigameGameManager.cardDeck.Remove(systemManager.blackjackMinigameGameManager.cardDeck[0]);
    }
}
