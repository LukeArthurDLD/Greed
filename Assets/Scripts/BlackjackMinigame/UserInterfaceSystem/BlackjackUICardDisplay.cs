using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlackjackUICardDisplay : MonoBehaviour
{
    [Header("Parent - Blackjack UI System | Manager")][SerializeField]
    internal BlackjackUISystem systemManager;
    
    [Header("Prefabs")]
    public GameObject playerSpawn;
    public GameObject dealerSpawn;

    [Header("UI Elements")]
    public GameObject UIContainer;
    public GameObject cardTemplate;

    // Start is called before the first frame update
    void Start()
    {
        /* DEBUG */
        Debug.Log("Blackjack UI System | Card Display");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
