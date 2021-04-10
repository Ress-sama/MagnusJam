using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    Canvas canvas;
    RectTransform rectTransform;
    GameObject parent;
    CanvasGroup canvasGroup;
    public ButtonType buttonType;
    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        parent = transform.parent.gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(canvas.transform);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        SetDefaultPosition();
    }
    public void SetDefaultPosition()
    {
        transform.SetParent(parent.transform);
        transform.localPosition = Vector3.zero;
    }

}
