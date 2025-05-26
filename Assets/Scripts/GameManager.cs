using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text distanceText;
    public GameObject gameOverPanel;
    public Transform plane;

    private float startX;
    private bool isGameOver = false;

    void Awake()
    {
        Instance = this;
        startX = plane.position.x;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (isGameOver) return;

        float distance = plane.position.x - startX;
        distanceText.text = $"°Å¸®: {distance:F1} m";
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
