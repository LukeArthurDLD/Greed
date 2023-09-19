using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTuner : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    float animSpeed; 

    public AnimatorClipInfo[] currentClipInfo;


    private bool isFinished = false;

    private string[] stateParameters = { "isIdle", "isMoving", "enemyDetected", "isAttacking" };

    public bool enemyDetected = false;
    public bool isAttacking = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // Cache - Animator
        _animator = GetComponent<Animator>();

        // Reset - Animation Speed Multiplier
        ResetAnimationSpeedMultiplier();

        // Get - Current Animation Information
        GetCurrentAnimationInformation();
    }

    void Update()
    {
        // Get - Current Animation Information
        GetCurrentAnimationInformation();

        // Tune - Animation Speed Multiplier
        TuneAnimationSpeedMultiplier();

        // ResetStateMachine();

        CheckCurrentAnimationProgress();

        //if (enemyDetected == true)
        //{
        //    if ((currentClipInfo[0].clip.name == "Idle_Gun_Lowered") && (isFinished == true))
        //    {
        //        TransitionToNextAnimation(stateParameters[2]);
        //    }
        //    if ((currentClipInfo[0].clip.name == "Walk_Gun_Lowered") && (isFinished == true))
        //    {
        //        TransitionToNextAnimation(stateParameters[2]);
        //    }
        //}
        //if (isAttacking == true)
        //{
        //        TransitionToNextAnimation(stateParameters[3]);
        //}
        
    }

    void ResetStateMachine()
    {
        if (enemyDetected == false)
        {
            _animator.SetBool("enemyDetected", false);
        }

        if (isAttacking == false)
        {
            _animator.SetBool("isAttacking", false);
        }
    }

    void GetCurrentAnimationInformation()
    {
        // Get = Current Animation Clip Information from Animator Controller
        currentClipInfo = _animator.GetCurrentAnimatorClipInfo(0);

        Debug.Log("Current animation: " + currentClipInfo[0].clip.name);
    }

    private void ResetAnimationSpeedMultiplier()
    {
        // Reset = Initial Value for Animation Speed Multiplier
        animSpeed = 1f;

        // Set - Animation Speed Multiplier in Animator Controller
        _animator.SetFloat("animSpeed", animSpeed);
    }

    private void TuneAnimationSpeedMultiplier()
    {
        /*  ALGORITHM
        *   
        *   Animation Speed = (Animation Key Frame Total - 1 Frame) / Unity Sampling Rate (30 Frames)
        *   Unity Sampling Rate Set at 30 FPS
        *
        */

        // Get = Current Animation Length for Animation Clip
        animSpeed = currentClipInfo[0].clip.length;

        // Set - Animation Speed Multiplier in Animator Controller
        _animator.SetFloat("animSpeed", animSpeed);
    }

    void CheckCurrentAnimationProgress ()
    {
        // Reset - Checker
        isFinished = false;

        // Check - If Current Animation is Finished
        if (_animator.GetCurrentAnimatorStateInfo(0).length >= 1)
        {
            Debug.Log("Clip has finished playing!");
            isFinished = true;
        }
        else
        {
            Debug.Log("Clip is still playing...");
            isFinished = false;
        }
    }

    void TransitionToNextAnimation(string stateName)
    {
        _animator.SetBool(stateName, true);
    }
}
