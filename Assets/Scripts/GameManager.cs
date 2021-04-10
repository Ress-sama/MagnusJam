using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string LeftButton { get; set; }
    public static string RightButton { get; set; }

    GameObject leftButton;
    GameObject rightButton;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
    }
    public void PlayGame()
    {
        leftButton = GameObject.Find("Left");
        rightButton = GameObject.Find("Right");
        if (CheckButtons())
        {
            player.GetComponent<Player>().enabled = true;
        }
    }
    bool CheckButtons()
    {
        if(leftButton.transform.childCount <= 0 || rightButton.transform.childCount <= 0)
        {
            return false;
        }
        return true;
    }
}
