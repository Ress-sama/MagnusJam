using UnityEngine;
using UnityEngine.EventSystems;

public class MouseCell : MonoBehaviour, IDropHandler
{
    GameObject item;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 1)
        {
            item.GetComponent<ButtonManager>().SetDefaultPosition();
            DropButton(eventData);
        }
        else
        {
            DropButton(eventData);
        }
        SetButton(eventData);
    }
    void SetButton(PointerEventData eventData)
    {
        if (transform.name.Equals("Left"))
        {
            GameManager.LeftButton = item.GetComponent<ButtonManager>().buttonType.ToString();
        }
        else if (transform.name.Equals("Right"))
        {
            GameManager.RightButton = item.GetComponent<ButtonManager>().buttonType.ToString();
        }
    }

    void DropButton(PointerEventData eventData)
    {
        item = eventData.pointerDrag;
        item.transform.SetParent(transform);
        item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
}
