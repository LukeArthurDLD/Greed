using UnityEngine;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
    [SerializeField]
    internal UI_Management scriptUIManagement;
    
    void Start()
    {
        //scriptUIManagement.scriptScreenDatabase.panel_Screen_FadeTransition.SetActive(true);
        FadeInTransition();
        //scriptUIManagement.scriptScreenLoadingPrompt.Loading();
    }

    private void Awake()
    {
        FadeInTransition();
    }

    public void FadeInTransition()
    {
        ResetTransition(1);
        //scriptUIManagement.scriptScreenDatabase.panel_Screen_FadeTransition.GetComponent<Animation>().Play();
        //scriptUIManagement.scriptScreenDatabase.panel_Screen_FadeTransition.SetActive(false);
    }

    private void ResetTransition(int a)
    {
        //Color temp = scriptUIManagement.scriptScreenDatabase.panel_Screen_FadeTransition.GetComponent<Image>().color;
        //temp.a = a;
        //scriptUIManagement.scriptScreenDatabase.panel_Screen_FadeTransition.GetComponent<Image>().color = temp;
    }

    public void DebuggerDisableGameObject()
    {
        //scriptUIManagement.scriptScreenDatabase.panel_Screen_FadeTransition.SetActive(false);
    }
}
