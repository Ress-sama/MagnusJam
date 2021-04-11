using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class WinGate : MonoBehaviour
{

    Light2D winLight;
    bool win;

    private void Start()
    {
        win = false;
        winLight = GetComponentInChildren<Light2D>();
    }

    private void Update()
    {
        if (win)
        {
            winLight.pointLightOuterRadius += Time.deltaTime * 120f;
            if (winLight.pointLightOuterRadius > 500f)
            {
                GameManager.INSTANCE.LevelCompleteScreen();
                win = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player))
        {
            win = true;
        }
    }
}
