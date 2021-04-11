using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string LeftButton { get; set; }
    public static string RightButton { get; set; }

    [SerializeField]
    Transform hideMouse;
    [SerializeField]
    Transform showMouse;
    [SerializeField]
    Transform hideToolBar;
    [SerializeField]
    Transform showToolBar;
    [SerializeField]
    GameObject gameOverScreen;
    [SerializeField]
    GameObject levelCompleteScreen;

    GameObject leftButton;
    GameObject rightButton;
    GameObject player;
    GameObject mouse;
    GameObject toolBar;
    GameObject ready;
    bool showLevel;
    [Range(0, 10)]
    [SerializeField]
    float range;
    bool isShowUi;
    public static GameManager INSTANCE { get; set; }

    private void Start()
    {
        INSTANCE = this;
        player = GameObject.FindGameObjectWithTag(Tags.Player);
        showLevel = true;
        isShowUi = true;
    }
    private void Update()
    {
        if (showLevel)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, range, 0.5f * Time.deltaTime);
            if (range - Camera.main.orthographicSize <= 1)
            {
                range = 5;
                showLevel = false;
            }
        }
        else if (isShowUi)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, range, 0.5f * Time.deltaTime);
            if (Camera.main.orthographicSize - range <= 1)
            {
                ShowUI();
                isShowUi = false;
            }
        }
    }

    public void PlayGame()
    {
        leftButton = GameObject.Find(StaticFields.Left);
        rightButton = GameObject.Find(StaticFields.Right);
        if (CheckButtons())
        {
            player.GetComponent<Player>().enabled = true;
            HideUI();
        }
    }
    bool CheckButtons()
    {
        if (leftButton.transform.childCount <= 0 || rightButton.transform.childCount <= 0)
        {
            return false;
        }
        return true;
    }

    public void ShowUI()
    {
        mouse = GameObject.Find(StaticFields.Mouse);
        toolBar = GameObject.Find(StaticFields.ToolBar);
        ready = GameObject.Find(StaticFields.Ready);

        iTween.MoveTo(mouse, iTween.Hash("position", showMouse.position, "time", 1.4f, "easeType", iTween.EaseType.easeInBack));
        iTween.MoveTo(toolBar, iTween.Hash("position", showToolBar.position, "time", 1.4f, "easeType", iTween.EaseType.easeInBack));
        ready.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
    void HideUI()
    {

        mouse = GameObject.Find(StaticFields.Mouse);
        toolBar = GameObject.Find(StaticFields.ToolBar);
        ready = GameObject.Find(StaticFields.Ready);
        ready.transform.position = new Vector3(-1000, -5000, 0);

        iTween.MoveTo(mouse, iTween.Hash("position", hideMouse.position, "time", 1.4f, "easeType", iTween.EaseType.easeInBack));
        iTween.MoveTo(toolBar, iTween.Hash("position", hideToolBar.position, "time", 1.4f, "easeType", iTween.EaseType.easeInBack));

    }
    public void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LevelCompleteScreen()
    {
        levelCompleteScreen.SetActive(true);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
