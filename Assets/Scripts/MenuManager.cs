using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject Levels;
    [SerializeField]
    GameObject Picture;

    private void Start()
    {
        Levels.transform.position = new Vector3(-20,0,0);
    }

    public void ShowLevels()
    {
        iTween.MoveTo(Levels, iTween.Hash("position", Vector3.zero, "time", 0.8f, "easeType", iTween.EaseType.easeInBack));
        iTween.MoveTo(Picture, iTween.Hash("position", new Vector3(0,20,0), "time", 0.8f, "easeType", iTween.EaseType.easeInBack));

    }
    public void Quit()
    {
        Application.Quit();
    }
}
