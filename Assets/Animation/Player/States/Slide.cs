using UnityEngine;

public class Slide : StateMachineBehaviour
{
    Player player;
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject.GetComponent<Player>();
        player.CanSlide = true;
        player.boxCollider.size = new Vector2(1.3f, 2.75f);
        player.boxCollider.offset = new Vector2(0, 0);
    }

}
