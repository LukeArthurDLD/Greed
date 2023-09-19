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

[CreateAssetMenu(fileName = "New CD", menuName = "Scriptable Object/CD Casino")]
public class CD_Casino : ScriptableObject
{
    [Header("Background Music")]

    public AudioClip backgroundMusic;
    public AudioClip bossBattleMusic_Ace;

    [Header("Character Sound FX")]

    public AudioClip[] playerFootsteps;
    public AudioClip[] enemyFootsteps;
    public AudioClip[] enemyCasinoStaffVoiceQuotes;
    public AudioClip[] enemyAceVoiceQuotes;

    public AudioClip[] aceTaunt;

    [Header("UI Sound FX")]

    public AudioClip bing;
    public AudioClip changeWeaponSound;
    public AudioClip changeAmmunitionSound;

    public AudioClip announcementPlayerWin;
    public AudioClip announcementPlayerLoss;

    [Header("Weapon Sound FX")]

    public AudioClip weaponTriggerPull;
    
    public AudioClip shotgunShot;
    public AudioClip shotgunPumpAction;
    public AudioClip shotgunShellDrop;
    public AudioClip shotgunShellReload;
    
    public AudioClip[] tommygunShot;
    public AudioClip tommygunBulletCasingDrop;
    public AudioClip tommygunDrumMagClick;
    public AudioClip tommygunDiscardEmptyDrumMag;
    public AudioClip tommygunRetrieveNewDrumMag;

    public AudioClip revolverShot;
    public AudioClip revolverReleasePinWheelDrop;
    public AudioClip revolverShakingMultipleBulletCasingsOutOfWheel;
    public AudioClip revolverMultipleBulletCasingHittingGround;
    public AudioClip revolverReloadNewBullet;
    public AudioClip revolverTurnPinWheel;
    public AudioClip revolverSpinPinWheel;
    public AudioClip revolverPinWheelClick;

    public AudioClip[] meleeHit;

    public AudioClip equipment8BallThrow;
    public AudioClip equipmentBrickPhoneThrow;
    public AudioClip equipmentBrickPhoneExplosion;
    public AudioClip equipmentNewEquipment;

    [Header("Environment Sound FX")]

    public AudioClip casinoSlotMachines;

    public AudioClip casinoPokerChipsClattering;
    
    public AudioClip casinoRouletteWheelSpinning;
    public AudioClip casinoRouletteWheelBallHittingWheel;
    public AudioClip casinoRouletteDraggingPokerChips;

    //[Header("Prop Sound FX")]
}
