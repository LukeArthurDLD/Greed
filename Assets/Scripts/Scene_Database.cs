using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  ASSET DESCRIPTION
 *  
 *  Scriptable Object for Scene Database
 *  
 *  Scriptable Parameters:
 *      - Game Scenes
 */

[CreateAssetMenu(fileName = "New Scene Database", menuName = "Scriptable Object/Scene Database")]
public class Scene_Database : ScriptableObject
{
    [Header("Scene 0000")]
    public Scene_Management mainMenu;

    [Header("Scene 0001")]
    public Scene_Management blackjack;

    [Header("Scene 0002")]
    public Scene_Management casino;
}
