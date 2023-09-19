using UnityEngine;

/*  PLAY AUDIO COMPONENT SCRIPT
 *  
 *  VERSION: 2021.11.02 AUTHOR: T. Smith
 *  
 *  DESCRIPTION
 *  
 *  Script is used for playing audio files (.mp3, .wav etc.)
 *  Script will create an instance of an 'AudioSource' component on attached GameObject
 *  Script will play audio stored within public variable 'AudioFile'
 *  Script is modular for randomization of Sound FX
 *  
 *  DIRECTIONS FOR USE:
 *  
 *  1. Attach to any game object inside inspector
 *  2a. Put a audio file in the public variable 'AudioFile'
 *  OR
 *  2b. Put multiple audio files in the public array 'SoundFX'
 *  
 */

public class PlaySound : MonoBehaviour
{
    private AudioSource _audioSource;
    
    [Header("Audio to Play")]
    public AudioClip audioFile;

    [Header("Sound Effects")]
    public AudioClip[] soundFX;

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = audioFile;
        PlayAudio();
    }

    public void PlayAudio()
    {
        _audioSource.Play();
    }

    public void ChangeAudio (AudioClip _aC)
    {
        _audioSource.clip = _aC;
    }

    public void RandomizeAudio()
    {
        int _rand = Random.Range(0, soundFX.Length);
        audioFile = soundFX[_rand];
        ChangeAudio(audioFile);
    }
}
