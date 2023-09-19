using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*  ASSET NAME: UI Game System | Black Card Generator
 *  
 *  VERSION: 1.00
 *      1.00 (2021.11.03) | AUTHOR: T. Smith
 */

public class BlackjackUISystem : MonoBehaviour
{
    // Description
    // Each Card is 100 Width, 150 Height >> rectTransform.sizeDelta = new Vector2(100, 150)

    // X Card | 100 + i * 110
    // 1 Card | 100 + (0) * 110 = 100
    // 2 Cards | 100 + (1) * 110 = 210
    // 3 Cards | 100 + (2) * 110 = 320
    // 4 Cards | 100 + (3) * 110 = 430
    // 5 Cards | 100 + (4) * 110 = 540

    // transform.position at rectTransform.sizeDelta.x/card Count, 0, 0 &
    // transform.position at -50,0,0
    // transform.position at -105,0,0 & 210,0,0
    //

    // NOTE > Screen.width is not set, it scales to game window!
    // UI / Horizontal Layout Group >> For spacing & Realignment
    // Create a list to add and regenerate display of cards

    [Header("Parent - Blackjack Minigame | Game Manager")][SerializeField]
    internal BlackjackMinigame blackjackMinigameGameManager;

    [Header("Child - Blackjack UI System | Card Display")][SerializeField]
    internal BlackjackUICardDisplay cardDisplay;

    [Header("Child - Blackjack UI System | Text Display")][SerializeField]
    internal BlackjackUITextDisplay textDisplay;

    // UI Elements
    [Header("Card Parameters to Display")]
    public Sprite cardCanvas;
    public Sprite cardBackcover;
    public TMP_Text[] cardTypeText;

    [Header("Text Display")]
    public TMP_Text playerHandText;
    public TMP_Text dealerHandText;

    // Player Card Cache
    private List<PlayingCard> playerCardCache = new List<PlayingCard>();

    // Dealer Card Cache
    private List<PlayingCard> dealerCardCache = new List<PlayingCard>();

    // Instantiated Player Cards Cache
    private List<GameObject> playerInstantiatedCardsCache = new List<GameObject>();

    // Instantiated Dealer Cards Cache
    private List<GameObject> dealerInstantiatedCardsCache = new List<GameObject>();

    [Header("Prefabs")]
    public GameObject playerZoneSpawn;
    public GameObject dealerZoneSpawn;

    [Header("UI Elements")]
    public GameObject UIContainer;
    public GameObject cardTemplate;

    // Instantiated Game Objects
    GameObject _instantiatedDealerUIContainer;
    GameObject _instantiatedPlayerCard;
    GameObject _instantiatedDealerCard;
    GameObject _instantiatedPlayerUIContainer;

    private void Start()
    {
        /* DEBUG */
        Debug.Log("Blackjack UI System | Manager");

        // Generate - UI Containers
        GenerateUIContainer();

        // Construct - Player Hand
        ConstructHand();
    }

    void Update()
    {
        // Update - Text Display
        textDisplay.DisplayText();

        // Update - Card Display
        DisplayCard();
    }

    public void ConstructHand()
    {
        ScaleUIContainer();

        RefreshInstantiatedGameObjects();

        RefreshCardCache();

        GenerateCards();
    }

    internal void GenerateUIContainer()
    {
        // Instantiate - UI Container in Player Spawn
        _instantiatedPlayerUIContainer = Instantiate(UIContainer, playerZoneSpawn.transform, false);
        _instantiatedPlayerUIContainer.name = "Player UI Container";

        // Instantiate - UI Container in Dealer Spawn
        _instantiatedDealerUIContainer = Instantiate(UIContainer, dealerZoneSpawn.transform, false);
        _instantiatedDealerUIContainer.name = "Dealer UI Container";
    }

    public void ScaleUIContainer() 
    {
        // Calculate - Scale of PLayer UI Container
        float _playerUIContainerAlgorithm = (blackjackMinigameGameManager.playersCards.Count - 1) * 110;

        // Scale - Player UI Container
        _instantiatedPlayerUIContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(100 + _playerUIContainerAlgorithm, 150);

        // Calculate - Scale of Dealer UI Container
        float _dealerUIContainerAlgorithm = (blackjackMinigameGameManager.dealersCards.Count - 1) * 110;

        // Scale - Dealer UI Container
        _instantiatedDealerUIContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(100 + _dealerUIContainerAlgorithm, 150);
    }

    public void RefreshInstantiatedGameObjects()
    {
        // Destroy - Every Game Object in Instantiated Player Cards Cache
        foreach (GameObject o in playerInstantiatedCardsCache)
        {
            Destroy(o);
        }

        // Clear - Instantiated Player Cards
        playerInstantiatedCardsCache.Clear();

        // Destroy - Every Game Object in Instantiated Dealers Cards Cache
        foreach (GameObject o in dealerInstantiatedCardsCache)
        {
            Destroy(o);
        }

        // Clear - Instantiated Dealer Cards
        dealerInstantiatedCardsCache.Clear();
    }

    public void RefreshCardCache()
    {
        // Reset - Card Cache
        playerCardCache.Clear();

        // For - Every Card in Players Cards
        foreach (PlayingCard c in blackjackMinigameGameManager.playersCards)
        {
            // Add - Card to Card Cache
            playerCardCache.Add(c);
        }

        // Reset - Card Cache
        dealerCardCache.Clear();

        // For - Every Card in Dealers Cards
        foreach (PlayingCard c in blackjackMinigameGameManager.dealersCards)
        {
            // Add - Card to Card Cache
            dealerCardCache.Add(c);
        }
    }

    public void GenerateCards() 
    {
        // For - Every Card in the Players Card Cache 
        for (int i = 0; i < playerCardCache.Count; i++)
        {
            // Instantiate - Card Prefab in Instantiated UI Container
            _instantiatedPlayerCard = Instantiate(cardTemplate, _instantiatedPlayerUIContainer.transform, false);
            _instantiatedPlayerCard.name = playerCardCache[i].name;

            // Add - Player Instantiated Card to Player Instantiated Cards Cache
            playerInstantiatedCardsCache.Add(_instantiatedPlayerCard);

            // Adjust - Instantiated Prefab to Fit 
            Vector3 _v = _instantiatedPlayerCard.transform.position;
            _v = new Vector3(_v.x + (i * 55), _v.y, _v.z);
        }

        // For - Every Card in the Dealers Card Cache 
        for (int i = 0; i < dealerCardCache.Count; i++)
        {
            // Instantiate - Card Prefab in Instantiated UI Container
            _instantiatedDealerCard = Instantiate(cardTemplate, _instantiatedDealerUIContainer.transform, false);

            // Hide - Dealers Instantiated Card
            if ((i == 0) && (blackjackMinigameGameManager.playersTurn == true))
            {
                // Source - Backcover for Card
                _instantiatedDealerCard.GetComponent<Image>().sprite = cardBackcover;

                // Hide - Name
                _instantiatedDealerCard.name = dealerCardCache[i].name = "Hidden Card";

                // Hide - Icon for Suit
                _instantiatedDealerCard.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 0);

                // Hide - Icon for Type
                for (int j = 1; j <= cardTypeText.Length; j++)
                {
                    _instantiatedDealerCard.transform.GetChild(j).GetComponent<TMP_Text>().text = "";
                }
            }
            // Show - Dealers Instantiated Card
            else
            {
                // Source - Name of Dealers Instantiated Card
                _instantiatedDealerCard.name = dealerCardCache[i].name;
            }

            // Add - Dealer Instantiated Card to Dealer Instantiated Cards Cache
            dealerInstantiatedCardsCache.Add(_instantiatedDealerCard);

            // Adjust - Instantiated Prefab to Fit 
            Vector3 _v = _instantiatedDealerCard.transform.position;
            _v = new Vector3(_v.x + (i * 55), _v.y, _v.z);
        }
    }

    public void DisplayCard()
    {
        // Construct - Card Display for Player Instantiated Cards
        for (int i = 0; i < playerInstantiatedCardsCache.Count; i++)
        {
            // Source - Background for Card
            playerInstantiatedCardsCache[i].GetComponent<Image>().sprite = cardCanvas;

            // Source - Icon for Card Suit
            playerInstantiatedCardsCache[i].transform.GetChild(0).GetComponent<Image>().sprite = playerCardCache[i].iconSuit;

            // Check - If Card Suit is Diamonds OR Hearts
            if (playerCardCache[i].cardSuit == "Diamonds" || playerCardCache[i].cardSuit == "Hearts")
            {
                // Change - Color of Icon to Red
                playerInstantiatedCardsCache[i].transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            }

            // Check - If Card Suit is Clubs OR Spades
            if (playerCardCache[i].cardSuit == "Clubs" || playerCardCache[i].cardSuit == "Spades")
            {
                // Change - Color of Icon to Black
                playerInstantiatedCardsCache[i].transform.GetChild(0).GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            }

            // Source - Icon for Card Type
            for (int j = 1; j <= cardTypeText.Length; j++)
            {
                playerInstantiatedCardsCache[i].transform.GetChild(j).GetComponent<TMP_Text>().text = playerCardCache[i].iconSymbol;   
            }
        }

        // Construct - Card Display for Dealer Instantiated Cards
        for (int i = 0; i < dealerInstantiatedCardsCache.Count; i++)
        {
            // Hide - Dealers First Card
            if ((i == 0) && (blackjackMinigameGameManager.playersTurn == true))
            {
                // Source - Backcover for Card
                _instantiatedDealerCard.GetComponent<Image>().sprite = cardBackcover;

                // Hide - Name
                _instantiatedDealerCard.name = dealerCardCache[i].name = "Hidden Card";

                // Hide - Icon for Suit
                _instantiatedDealerCard.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 0);

                // Hide - Icon for Type
                for (int j = 1; j <= cardTypeText.Length; j++)
                {
                    _instantiatedDealerCard.transform.GetChild(j).GetComponent<TMP_Text>().text = "";
                }
            }
            // Create - Card Display
            else
            {
                // Source - Card Canvas for Card
                dealerInstantiatedCardsCache[i].GetComponent<Image>().sprite = cardCanvas;

                // Source - Icon for Card Suit
                dealerInstantiatedCardsCache[i].transform.GetChild(0).GetComponent<Image>().sprite = dealerCardCache[i].iconSuit;

                // Check - If Card Suit is Diamonds OR Hearts
                if (dealerCardCache[i].cardSuit == "Diamonds" || dealerCardCache[i].cardSuit == "Hearts")
                {
                    // Change - Color of Icon to Red
                    dealerInstantiatedCardsCache[i].transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                }

                // Check - If Card Suit is Clubs OR Spades
                if (dealerCardCache[i].cardSuit == "Clubs" || dealerCardCache[i].cardSuit == "Spades")
                {
                    // Change - Color of Icon to Black
                    dealerInstantiatedCardsCache[i].transform.GetChild(0).GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                }

                // Source - Icon for Card Type
                for (int j = 1; j <= cardTypeText.Length; j++)
                {
                    dealerInstantiatedCardsCache[i].transform.GetChild(j).GetComponent<TMP_Text>().text = dealerCardCache[i].iconSymbol;
                }
            }
        }
    }
}
