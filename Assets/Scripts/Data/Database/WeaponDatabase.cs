using System.Collections.Generic;
using UnityEngine;

/*  ASSET NAME: Weapon Database | Manager
 *  
 *  VERSION: 1.01
 *      1.01 (2021.11.02) | AUTHOR: T. Smith
 *      1.01 (2021.11.03) | AUTHOR: T. Smith
 *      
 *  DESCRIPTION
 *  
 *      Manages Weapon Items
 *  
 *      Scriptable Parameters:
 *      - Sidearms
 *      - Shotguns
 *      - Sub Machine Guns
 */

[CreateAssetMenu(menuName = "Database/Weapons")]
public class WeaponDatabase : ScriptableObject
{
    [Header("Firearms")]
    public List<Sidearm> sidearms = new List<Sidearm>();
    public List<Rifle> shotguns = new List<Rifle>();
    public List<SubMachineGun> subMachineGuns = new List<SubMachineGun>();
}
