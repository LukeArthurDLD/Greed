using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPrompt : MonoBehaviour
{
    [SerializeField]
    internal UI_Management scriptUIManagement;

    public GameObject loadingBar;
    
    void Start()
    {
        //scriptUIManagement.scriptScreenDatabase.panel_Screen_LoadingPrompt.SetActive(false);
    }

    public void Loading()
    {
        //scriptUIManagement.scriptScreenDatabase.panel_Screen_LoadingPrompt.SetActive(true);
        //loadingBar.GetComponent<Animation>().Play();
        //scriptUIManagement.scriptScreenDatabase.panel_Screen_LoadingPrompt.SetActive(false);
        //scriptUIManagement.scriptScreenFX.FadeInTransition();
    }

    public void DebuggerDisableGameObject()
    {
        //scriptUIManagement.scriptScreenDatabase.panel_Screen_LoadingPrompt.SetActive(false);
    }
}
