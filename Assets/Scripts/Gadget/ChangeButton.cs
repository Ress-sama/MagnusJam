using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButton : MonoBehaviour
{

    GameObject mouse;
    GameObject toolBar;
    Player player;
    GameObject ready;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player))
        {
            mouse = GameObject.Find(StaticFields.Mouse);
            toolBar = GameObject.Find(StaticFields.ToolBar);
            ready = GameObject.Find(StaticFields.Ready);
            player = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<Player>();
            player.enabled = false;
            Vector3 targetReady = new Vector3(ready.transform.position.x + 1000, ready.transform.position.y);
            Vector3 targetMouse = new Vector3(mouse.transform.position.x - 800, mouse.transform.position.y);
            Vector3 targetToolBar = new Vector3(toolBar.transform.position.x + 300, toolBar.transform.position.y);


            iTween.MoveTo(mouse, iTween.Hash("position", targetMouse, "time", 0.2f, "easeType", iTween.EaseType.easeInBack));
            iTween.MoveTo(toolBar, iTween.Hash("position", targetToolBar, "time", 0.2f, "easeType", iTween.EaseType.easeInBack));
            ready.transform.position = targetReady;
        }
    }

}
