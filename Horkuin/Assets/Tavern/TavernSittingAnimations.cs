using UnityEngine;

public class TavernSittingAnimations : StateMachineBehaviour
{
    private static readonly int AnimationID = Animator.StringToHash("AnimationID");

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger(AnimationID, Random.Range(1, 8));
    }
}
