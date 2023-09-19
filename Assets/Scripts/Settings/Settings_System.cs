using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings_System : MonoBehaviour
{
    // Scene - Database
    [SerializeField]

        public Scene_Database sceneDatabase;

    [Header("Child Script")]

        [SerializeField]
        internal Settings_Visual scriptVisual;

        [SerializeField]
        internal Settings_Audio scriptAudio;

        [SerializeField]
        internal Settings_UserInterface scriptUserInterface;

    [Header("UI Display")]

    public TMP_Text frameRateDisplay;

    private float musicVolume;
    private float soundFXvolume;

    private int updateUICounter;

    public bool frameRateCounter = false;

    

    // Start is called before the first frame update
    void Start()
    {
        ClearPlayerPrefs();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateUICounter++;

        if (updateUICounter == 20)
        {
            frameRateDisplay.GetComponent<TMP_Text>().text = scriptUserInterface.frameRate.ToString();

            updateUICounter = 0;
        }
    }

    void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
