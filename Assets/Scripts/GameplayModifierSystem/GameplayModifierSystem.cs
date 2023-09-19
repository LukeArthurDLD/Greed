using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*  ASSET NAME: Gameplay Modifier System | Manager
 *  
 *  VERSION: 1.01
 *      1.01 (2021.11.02) | AUTHOR: T. Smith
 *      1.01 (2021.11.03) | AUTHOR: T. Smith
 */

public class GameplayModifierSystem : MonoBehaviour
{
    [Header("Active Gameplay Data")][SerializeField]
    public GameplayData activeGameplayData;

    [Header("Parent - Blackjack Minigame | Game Manager")][SerializeField]
    internal BlackjackMinigame blackjackMinigameGameManager;

    public List<Modifier> modifiers = new List<Modifier>();

    internal Modifier gameplayModifier;

    public PlayerModifierManager modifierManager;

    internal string activeModifierName;
    internal Sprite activeModifierCategory;
    internal Sprite activeModifierType;

    void Start()
    {
        /* DEBUG */
        Debug.Log("Gameplay Modifier System | Manager");
    }

    internal void ConstructModifierList()
    {
        // Clear - Modifiers
        modifiers.Clear();

        // Check - If Player Wins
        if (blackjackMinigameGameManager.playerWin == true)
        {
            // Debug.Log("Player Wins - Getting Mod List");

            //// modifiers = new List<Modifier>(blackjackMinigameGameManager.dataSource.modifierDatabase.positiveModifiers);

            for (int i = 0; i < blackjackMinigameGameManager.dataSource.modifierDatabase.positiveModifiers.Count; i++)
            {
                modifiers.Add(blackjackMinigameGameManager.dataSource.modifierDatabase.positiveModifiers[i]);
            }

            RandomModifier();
            int modifierIndex = Random.Range(1, 3);
            if (modifierIndex == 1)
            {
                activeGameplayData.activeModifierMultiplier = 1.5f;
                activeGameplayData.activeModifierType = "Damage";


            }
            else if (modifierIndex == 2)
            {
                modifierManager.SetSpeed(1.5f);

                activeGameplayData.activeModifierMultiplier = 1.5f;
                activeGameplayData.activeModifierType = "Speed";
            }
            else
            {
                modifierManager.setArmour(0.5f);

                activeGameplayData.activeModifierMultiplier = 0.5f;
                activeGameplayData.activeModifierType = "Armour";
            }
        }

        // Check - If Dealer Wins
        if (blackjackMinigameGameManager.dealerWin == true)
        {
            //Debug.Log("Dealer Wins - Getting Mod List");

            // modifiers = new List<Modifier>(blackjackMinigameGameManager.dataSource.modifierDatabase.positiveModifiers);

            for (int i = 0; i<blackjackMinigameGameManager.dataSource.modifierDatabase.negativeModifiers.Count; i++)
            {
                modifiers.Add(blackjackMinigameGameManager.dataSource.modifierDatabase.negativeModifiers[i]);
            }

Debug.Log("Outside Loop - Mod List");

            RandomModifier();
int modifierIndex = Random.Range(1, 3);
            if (modifierIndex == 1)
            {
                activeGameplayData.activeModifierMultiplier = 0.75f;
                activeGameplayData.activeModifierType = "Damage";


            }
            else if (modifierIndex == 2)
            {
                modifierManager.SetSpeed(0.75f);

                activeGameplayData.activeModifierMultiplier = 1.5f;
                activeGameplayData.activeModifierType = "Speed";
            }
            else
            {
                modifierManager.setArmour(0.5f);

                activeGameplayData.activeModifierMultiplier = 1.35f;
                activeGameplayData.activeModifierType = "Armour";
            }
        }
        if (blackjackMinigameGameManager.gameDraw == true)
        {
            // modifiers = new List<Modifier>(blackjackMinigameGameManager.dataSource.modifierDatabase.positiveModifiers);

            int modifierIndex = Random.Range(1, 3);
            if (modifierIndex == 1)
            {
                modifierManager.SetDamage();
            }
            else if (modifierIndex == 2)
            {
                modifierManager.SetSpeed();
            }
            else
            {
                modifierManager.setArmour();
            }









            for (int i = 0; i<blackjackMinigameGameManager.dataSource.modifierDatabase.positiveModifiers.Count; i++)
            {
                modifiers.Add(blackjackMinigameGameManager.dataSource.modifierDatabase.positiveModifiers[i]);
            }
            for (int i = 0; i<blackjackMinigameGameManager.dataSource.modifierDatabase.negativeModifiers.Count; i++)
            {
                modifiers.Add(blackjackMinigameGameManager.dataSource.modifierDatabase.negativeModifiers[i]);
            }

            RandomModifier();
  
    }
    }
    
    internal void RandomModifier()
    {
        int _rand = Random.Range(0, modifiers.Count);
        gameplayModifier = modifiers[_rand];

        // Enable - Next Level Transition
        blackjackMinigameGameManager.nextLevel = true;

        // Display - Modifier Name
        activeModifierName = gameplayModifier.modifierName;

        // Display - Modifier Category
        activeModifierCategory = gameplayModifier.modifierCategoryIcon;

        // Display - Modifier Type
        activeModifierType = gameplayModifier.modifierTypeIcon;
    }
}
