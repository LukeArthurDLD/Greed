using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Management : MonoBehaviour
{
    [SerializeField]
    internal MenuNavigation scriptMenuNavigation;

    [SerializeField]
    internal FadeTransition scriptScreenFadeTransition;

    [SerializeField]
    internal LoadingPrompt scriptScreenLoadingPrompt;

    [SerializeField]
    internal UI_Modifier scriptUIModifier; //PLACEHOLDER

    // Current Scene - Build Index
    internal int _currentBuildIndex = 0;

    // HUD Elements
    internal string activeModifier;
    public TMP_Text displayMod;

    // DEBUGGING TOOL
    public GameObject activeScene;

    void Start()
    {
        // Setup Initial Scene - Level 0000 - Dashboard & Menus
        //scriptScreenDatabase.panel_Menu_Dashboard.SetActive(false);
        //scriptScreenDatabase.panel_Menu_Options.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Running debug disable action!");
        }

        DisplayUI();
    }

    public void DisplayUI()
    {
        //displayMod.text = activeModifier;
    }

    /*private void Scene_Level_0002_Casino ()
    {
        panel_Screen_FadeTransition.SetActive(true);
        panel_Screen_LoadingScreen.SetActive(true);
        panel_Game_Mini_Blackjack.SetActive(true);
        panel_Game_Main_FPS.SetActive(true);
        panel_Menu_Pause.SetActive(true);
        panel_Menu_Settings.SetActive(true);
    }

    private void Scene_Level_9999_End()
    {
        panel_Production_Credits.SetActive(false);
    }*/
}
