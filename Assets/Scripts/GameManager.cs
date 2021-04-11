using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string LeftButton { get; set; }
    public static string RightButton { get; set; }

    GameObject leftButton;
    GameObject rightButton;
    GameObject player;
    GameObject mouse;
    GameObject toolBar;
    GameObject ready;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
    }
    public void PlayGame()
    {
        leftButton = GameObject.Find("Left");
        rightButton = GameObject.Find("Right");
        mouse = GameObject.Find(StaticFields.Mouse);
        toolBar = GameObject.Find(StaticFields.ToolBar);
        ready = GameObject.Find(StaticFields.Ready);

        if (CheckButtons())
        {
            player.GetComponent<Player>().enabled = true;
        }

        Vector3 targetMouse = new Vector3(mouse.transform.position.x + 800, mouse.transform.position.y);
        Vector3 targetToolBar = new Vector3(toolBar.transform.position.x - 300, toolBar.transform.position.y);
        Vector3 targetReady = new Vector3(ready.transform.position.x - 1000, ready.transform.position.y);

        ready.transform.position = targetReady;
        iTween.MoveTo(mouse, iTween.Hash("position", targetMouse, "time", 1.4f, "easeType", iTween.EaseType.easeInBack));
        iTween.MoveTo(toolBar, iTween.Hash("position", targetToolBar, "time", 1.4f, "easeType", iTween.EaseType.easeInBack));

    }
    bool CheckButtons()
    {
        if (leftButton.transform.childCount <= 0 || rightButton.transform.childCount <= 0)
        {
            return false;
        }
        return true;
    }
}
