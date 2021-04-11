using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerEnter.CompareTag(Tags.Level))
        {
            SceneManager.LoadScene(int.Parse(eventData.pointerEnter.name));
        }
    }
}
