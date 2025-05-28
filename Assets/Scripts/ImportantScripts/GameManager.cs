using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text distanceText;
    public TMP_Text currentScoreText;
    public TMP_Text highScoreText;
    public GameObject gameOverPanel;
    public Transform plane;

    private float startX;
    private float currentDistance;
    private float highScore;
    private bool isGameOver = false;

    void Awake()
    {
        Instance = this;
        startX = plane.position.x;
        gameOverPanel.SetActive(false);

        // 최고 기록 불러오기 (PlayerPrefs에서)
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        UpdateHighScoreText();
    }

    void Update()
    {
        if (isGameOver) return;

        currentDistance = plane.position.x - startX;
        distanceText.text = $"거리: {currentDistance:F1} m";
    }

    public void GameOver()
    {
        Debug.Log("게임 오버");
        isGameOver = true;
        gameOverPanel.SetActive(true);

        UpdateCurrentScoreText();

        if (currentDistance > highScore)
        {
            highScore = currentDistance;
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
        }

        UpdateHighScoreText();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void UpdateCurrentScoreText()
    {
        currentScoreText.text = $"현재 기록: {currentDistance:F1} m";
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = $"최고 기록: {highScore:F1} m";
    }

    // ▶ 추가 기능들 -------------------------

    public void StartGame()
    {
        Debug.Log("게임 시작!");
        SceneManager.LoadScene("InfinityModeScene");  // 게임 씬 이름을 정확히 적으세요
    }

    public void HowToPlay()
    {
        Debug.Log("게임 방법 화면으로 이동!");
        SceneManager.LoadScene("TutorialScene");  // 게임 방법 씬 이름을 정확히 적으세요
    }

    public void GoToTitle()
    {
        Debug.Log("타이틀 화면으로 이동!");
        SceneManager.LoadScene("TitleScene");  // 타이틀 씬 이름을 정확히 적으세요
    }

    public void QuitGame()
    {
        Debug.Log("게임 종료!");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // 에디터에서 실행 중일 때
#else
        Application.Quit();  // 빌드된 게임에서
#endif
    }
}
