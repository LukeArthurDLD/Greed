using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  ASSET DESCRIPTION
 *  
 *  Scriptable Object for Scene Management
 *  
 *  Scriptable Parameters:
 *      - Game Manager
 *      - System Manager
 *      - Audio Manager
 */

[CreateAssetMenu(fileName = "New Scene Management", menuName = "Scriptable Object/Scene Management")]
public class Scene_Management : ScriptableObject
{
    [Header("Game Manager")]
    public GameObject gameManager;

    [Header("Audio Manager")]
    public GameObject audioManager;

    [Header("UI Manager")]
    public GameObject UIManager;
}
