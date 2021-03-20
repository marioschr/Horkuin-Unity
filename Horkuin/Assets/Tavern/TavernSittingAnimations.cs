using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernSittingAnimations : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("AnimationID", Random.Range(1, 8));
    }
}
