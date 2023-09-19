using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings_Audio : MonoBehaviour
{
    [Header("Parent Script")][SerializeField]
    internal Settings_System settingsSystemManager;

    // Cache - Audio Listener
    private AudioListener _audioListener;

    public AudioMixer audioMixer;

    [SerializeField]
    public Slider volumeSlider;

    private GameObject _audioManager;
    private GameObject _jukebox;
    private Transform _soundBoard;
    
    void Start()
    {
        _audioListener = GetComponent<AudioListener>();

        CurrentScene();

        Debug.Log("Audio Manager: " + _audioManager);

        _jukebox = _audioManager.transform.GetChild(0).gameObject;
        ChangeMusicVolume(0f);

        Debug.Log("Jukebox (Settings): " + _jukebox);

        _soundBoard = _audioManager.transform.GetChild(1);
    }

    public void CurrentScene()
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentBuildIndex == 0)
        {

            _audioManager = settingsSystemManager.sceneDatabase.mainMenu.audioManager;
        }
        else if (currentBuildIndex == 1)
        {
            _audioManager = settingsSystemManager.sceneDatabase.blackjack.audioManager;
        }
        else
        {
            _audioManager = settingsSystemManager.sceneDatabase.casino.audioManager;
        }
    }

    public void ChangeMusicVolume(float newVolume)
    {
        Debug.Log("New Volume: " + newVolume);

        PlayerPrefs.SetFloat("musicVolume", newVolume);
        audioMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("musicVolume"));

        Debug.Log("Audio Source Volume: " + _jukebox.GetComponent<AudioSource>().volume);
    }

    public void ChangeSFXVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("sfxVolume", newVolume);
        _soundBoard.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("sfxVolume");
    }

    public void ChangeGlobalVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("volume", newVolume);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }

    // Add to start of level manager
    public void SourceVolume ()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
}
