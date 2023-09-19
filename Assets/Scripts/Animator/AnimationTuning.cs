using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTuning : StateMachineBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private float _animSpeed = 1f;

    [SerializeField]
    private AnimatorClipInfo[] currentClipInfo;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _animator = animator;
        ResetAnimationSpeedMultiplier();

        GetCurrentAnimationInfo();
        TuneAnimationSpeedMultiplier();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //    
    // }

    void ResetAnimationSpeedMultiplier()
    {
        // Reset = Initial Value for Animation Speed Multiplier
        _animSpeed = 1f;

        // Set - Animation Speed Multiplier in Animator Controller
        _animator.SetFloat("animSpeed", _animSpeed);
    }

    void GetCurrentAnimationInfo()
    {
        // Get = Current Animation Clip Information from Animator Controller
        currentClipInfo = _animator.GetCurrentAnimatorClipInfo(0);
    }

    void TuneAnimationSpeedMultiplier()
    {
        /*  ALGORITHM
        *   
        *   Animation Speed = (Animation Key Frame Total - 1 Frame) / Unity Sampling Rate (30 Frames)
        *   Unity Sampling Rate Set at 30 FPS
        *
        */

        // Get = Current Animation Length for Animation Clip
        _animSpeed = currentClipInfo[0].clip.length;

        // Set - Animation Speed Multiplier in Animator Controller
        _animator.SetFloat("animSpeed", _animSpeed);
    }

    

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
