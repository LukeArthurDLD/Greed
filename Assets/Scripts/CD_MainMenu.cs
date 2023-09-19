using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  ASSET DESCRIPTION
 *  
 *  Scriptable Object for CDs
 *  
 *  Scriptable Parameters:
 *      - Background Music
 *      - Sound FX
 */

[CreateAssetMenu(fileName = "New CD", menuName = "Scriptable Object/CD Main Menu")]
public class CD_MainMenu : ScriptableObject
{
    [Header("Scene Audio Sources")]
    public GameObject sceneMusic;
    public GameObject characterSFX;
    public GameObject weaponSFX;
    
    [Header("Background Music")]
    public AudioClip mainMenuMusic;

    [Header("Character Sound FX")]
    public AudioClip[] footsteps;

    [Header("UI Sound FX")]

    public AudioClip startGameSnippet;
    public AudioClip startGameButtonFX;

    public AudioClip exitApplication;
    public AudioClip exitApplicationGameCasinoSlice;

    public AudioClip mouseClick;

    public AudioClip bass;
    public AudioClip bass2;
    public AudioClip bass3;

    //[Header("Environment Sound FX")]

    //[Header("Prop Sound FX")]
}
