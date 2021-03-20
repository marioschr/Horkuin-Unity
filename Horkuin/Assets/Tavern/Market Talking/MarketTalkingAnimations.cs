using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketTalkingAnimations : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("AnimationID", Random.Range(1, 7));
    }
}
