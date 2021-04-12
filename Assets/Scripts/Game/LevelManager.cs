using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerEnter.CompareTag(Tags.Level))
        {
            for(int i = 0; i < int.Parse(eventData.pointerEnter.name) - 2; i++)
            {
                if (!StaticFields.LevelDone[i])
                {
                    return;
                }
            }
            SceneManager.LoadScene(int.Parse(eventData.pointerEnter.name));
        }
    }
}
