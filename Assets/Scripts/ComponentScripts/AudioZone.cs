using UnityEngine;

/*  TRIGGER EVENT COMPONENT SCRIPT
 *  
 *  VERSION: 2021.11.02 AUTHOR: T. Smith
 *  
 *  DESCRIPTION
 *  
 *  Script is used for triggering events in-game
 *  Script will detect when player enters trigger
 *  Script will detect when player exits trigger
 *  Script is modular for any event initialization
 *  
 *  DIRECTIONS FOR USE:
 *  
 *  1. Inside script, set whatever event will be triggered
 *  2. Place prefab 'Trigger Zone' in scene
 *  3. Scale transform according to need
 *  
 */

public class AudioZone : MonoBehaviour
{
    public AudioClip music;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Entered Trigger Zone | Play Music!");
            
            _audioSource.clip = music;
            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _audioSource.Stop();
        }
    }
}
