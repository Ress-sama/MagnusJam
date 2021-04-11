using UnityEngine;

public class WinGate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player))
        {
            GameManager.INSTANCE.LevelCompleteScreen();
        }
    }
}
