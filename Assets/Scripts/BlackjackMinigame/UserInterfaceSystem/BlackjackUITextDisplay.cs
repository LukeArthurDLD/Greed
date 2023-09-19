using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlackjackUITextDisplay : MonoBehaviour
{
    [Header("Parent - Blackjack UI System | Manager")][SerializeField]
    internal BlackjackUISystem systemManager;

    [Header("Score Displays")]
    public TMP_Text playerHandText;
    public TMP_Text dealerHandText;

    [Header("Winners Banner Title")]
    public TMP_Text gameplayModifierTitleText;

    [Header("Winners Banner")]
    public TMP_Text winnersBannerText;

    [Header("Modifier Banner")]
    public TMP_Text gameplayModifierText;

    [Header("Modifier Display")]
    public Image gameplayModifierCategoryImage;
    public Image gameplayModifierTypeImage;

    void Start()
    {
        /* DEBUG */
        Debug.Log("Blackjack UI System | Text Display");
    }

    public void DisplayText()
    {
        if (systemManager.blackjackMinigameGameManager.gameEnd == true)
        {
            // Show - Modifier Display Image
            ShowModifierDisplayImage();

            if (systemManager.blackjackMinigameGameManager.playerWin == true)
            {
                // Display - Player Wins!
                winnersBannerText.text = "Player Wins!";

                // Display - Gameplay Modifier
                gameplayModifierTitleText.text = "Gameplay Modifier:";
            }
            else if (systemManager.blackjackMinigameGameManager.dealerWin == true)
            {
                // Display - Dealer Wins!
                winnersBannerText.text = "Dealer Wins!";

                // Display - Gameplay Modifier
                gameplayModifierTitleText.text = "Gameplay Modifier:";
            }
            else if (systemManager.blackjackMinigameGameManager.gameDraw == true)
            {
                // Display - Dealer Wins!
                winnersBannerText.text = "Its a Draw!";

                // Display - Gameplay Modifier
                gameplayModifierTitleText.text = "Gameplay Modifier:";
            }
            else
            {
                // Display - ERROR
                winnersBannerText.text = "ERROR THIS SHOULD NOT OCCUR!";
            }
        }
        else
        {
            // Hide - Modifier Display Image
            HideModifierDisplayImage();
        }

        // Display - Players Hand
        playerHandText.text = systemManager.blackjackMinigameGameManager.playersHand.ToString();

        // Display - Dealers Hand
        dealerHandText.text = systemManager.blackjackMinigameGameManager.dealersHand.ToString();

        //// Display - Gameplay Modifier Text
        //gameplayModifierText.text = systemManager.blackjackMinigameGameManager.gameplayModifierSystem.activeModifierName;

        //// Display - Gameplay Modifier Category Image
        //gameplayModifierCategoryImage.sprite = systemManager.blackjackMinigameGameManager.gameplayModifierSystem.activeModifierCategory;

        //// Display - Gameplay Modifier Type Image
        //gameplayModifierTypeImage.sprite = systemManager.blackjackMinigameGameManager.gameplayModifierSystem.activeModifierType;

        ChangeNegativeModifierColor();
    }

    void ChangePositiveModifierColor()
    {
        gameplayModifierText.color = new Color32(0, 0, 255, 255);
    }

    void ChangeNegativeModifierColor()
    {
        // White - 255 255 255 255
        // Black - 0 0 0 255

        // Red - 255 0 0 255
        // Green - 0 255 0 255
        // Blue - 0 0 255 255

        // Yellow - 255 255 0 255
        // Purple - 255 0 255 255
        // Cyan - 0 255 255 255

        playerHandText.color = new Color32(0, 0, 255, 255);
        dealerHandText.color = new Color32(255, 0, 0, 255);

        // gameplayModifierTitleText.color = new Color32(0, 255, 0, 255);

        winnersBannerText.color = new Color32(255, 255, 0, 255);

        // gameplayModifierText.color = new Color32(0, 255, 255, 255);
    }

    void HideModifierDisplayImage()
    {
        Color colorA = new Color32(255, 255, 255, 0);

     //   gameplayModifierCategoryImage.color = colorA;
        // gameplayModifierTypeImage.color = colorA;
    }

    void ShowModifierDisplayImage()
    {
        Color colorA = new Color32(255, 255, 255, 255);

        // gameplayModifierCategoryImage.color = colorA;
        // gameplayModifierTypeImage.color = colorA;
    }
}
