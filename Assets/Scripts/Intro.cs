using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    GameObject soundtrack;
    bool isMax = false;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        soundtrack = GameObject.Find("Soundtrack");
        DontDestroyOnLoad(soundtrack);
    }
    private void Update()
    {
        if (spriteRenderer.color.a < 1 && !isMax)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a + 0.005f);
        }
        else
        {
            isMax = true;
            if (spriteRenderer.color.a > 0.2f)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a - 0.001f);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }

    }
}
