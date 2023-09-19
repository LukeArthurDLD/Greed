using UnityEngine;

/*  ASSET NAME: Card Game System | Manager
 *  
 *  VERSION: 1.01
 *      1.01 (2021.11.02) | AUTHOR: T. Smith
 *      1.01 (2021.11.03) | AUTHOR: T. Smith
 */

public class CardGameSystem : MonoBehaviour
{
    /* - - - - - - - - - - - - - - - EXTENSIONS - - - - - - - - - - - - - - - - */

    [Header("Parent - Blackjack Minigame | Game Manager")][SerializeField]
    internal BlackjackMinigame blackjackMinigameGameManager;

    [Header("Child - Card Game System | Deck Operations")][SerializeField]
    internal CardGameDeckOperations deckOperations;

    /* - - - - - - - - - - - - - - - - - FUNCTIONALITY - - - - - - - - - - - - - */

    void Start()
    {
        /* DEBUG */
        Debug.Log("Card Game System | Manager");
    }
}
