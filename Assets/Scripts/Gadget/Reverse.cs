using System.Collections.Generic;
using UnityEngine;
public class Reverse : MonoBehaviour
{
    Dictionary<string, ButtonType> buttons;
    private void Start()
    {
        buttons = new Dictionary<string, ButtonType>();
        buttons.Add(ButtonType.Left.ToString(), ButtonType.Right);
        buttons.Add(ButtonType.Right.ToString(), ButtonType.Left);
        buttons.Add(ButtonType.JumpRight.ToString(), ButtonType.JumpLeft);
        buttons.Add(ButtonType.JumpLeft.ToString(), ButtonType.JumpRight);
        buttons.Add(ButtonType.SlideLeft.ToString(), ButtonType.SlideRight);
        buttons.Add(ButtonType.SlideRight.ToString(), ButtonType.SlideLeft);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(Tags.Player))
        {
            GameManager.LeftButton = buttons[GameManager.LeftButton].ToString();
            GameManager.RightButton = buttons[GameManager.RightButton].ToString();
        }
    }
}
