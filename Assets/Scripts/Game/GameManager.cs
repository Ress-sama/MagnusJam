using System.Collections;
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
    [SerializeField]
    Transform[] cameraPositions;

    GameObject leftButton;
    GameObject rightButton;
    GameObject player;
    GameObject mouse;
    GameObject toolBar;
    GameObject ready;
    Vector3 offset;
    bool showLevel;
    bool isShowUi;
    int index;
    [SerializeField]
    float transitionSpeed;
    public static GameManager INSTANCE { get; set; }

    private void Start()
    {
        offset = new Vector3(0f, 0f, 10f);
        index = 0;
        INSTANCE = this;
        player = GameObject.FindGameObjectWithTag(Tags.Player);
        showLevel = true;
        isShowUi = true;
    }
    private void Update()
    {
        if (showLevel)
        {
            if (index >= cameraPositions.Length)
            {
                showLevel = false;
                return;
            }
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, cameraPositions[index].position - offset, transitionSpeed * Time.deltaTime);
            if (Camera.main.transform.position == cameraPositions[index].position - offset)
            {
                index++;
            }
        }
        else if (isShowUi)
        {
            ShowUI();
            Camera.main.GetComponent<CameraManager>().enabled = true;
            isShowUi = false;
        }
    }

    public void PlayGame()
    {
        leftButton = GameObject.Find(StaticFields.Left);
        rightButton = GameObject.Find(StaticFields.Right);
        if (CheckButtons())
        {
            HideUI();
            StartCoroutine(SetActivePlayer());
        }
    }
    IEnumerator SetActivePlayer()
    {
        yield return new WaitForSeconds(2f);
        player.GetComponent<Player>().enabled = true;
        while (Camera.main.orthographicSize >= 5)
        {
            Camera.main.orthographicSize -= 0.05f;
            yield return new WaitForFixedUpdate();
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
        ready.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 400f);
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
