using UnityEngine;

public class ChangeButton : MonoBehaviour
{
    Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player))
        {
            player = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<Player>();
            player.enabled = false;
            GameManager.INSTANCE.ShowUI();
        }
    }

}
