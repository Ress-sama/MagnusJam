using UnityEngine;

public class Slide : StateMachineBehaviour
{
    Player player;
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject.GetComponent<Player>();
        player.CanSlide = true;
    }

}
