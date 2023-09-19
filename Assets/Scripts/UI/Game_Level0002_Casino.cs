using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Level0002_Casino : MonoBehaviour
{
    [SerializeField]
    internal UI_Management scriptUIManagement;
    
    void Start()
    {
        //scriptUIManagement.scriptScreenDatabase.panel_Game_Mini_Blackjack.SetActive(false);
        //scriptUIManagement.scriptScreenDatabase.panel_Game_Main_FPS.SetActive(false);
    }

    public void StartBlackjackGameplay()
    {
        //scriptUIManagement.scriptScreenDatabase.panel_Game_Mini_Blackjack.SetActive(true);
    }

    public void StartFPSGameplay()
    {
        //scriptUIManagement.scriptScreenDatabase.panel_Game_Main_FPS.SetActive(true);
    }
}

