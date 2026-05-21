using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private UIManager uiManager;
    private ScoreManager scoreManager;
    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        if (scoreManager == null)
            scoreManager = gameObject.AddComponent<ScoreManager>();

        if (uiManager == null)
            uiManager = FindObjectOfType<UIManager>();

        Time.timeScale = 1f;
    }

    public void AddScore(int points)
    {
        scoreManager.AddScore(points);
        uiManager?.UpdateScoreUI(scoreManager.GetScore());
    }

    public void UpdateHP(int hp)
    {
        uiManager?.UpdateHPUI(hp);
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        scoreManager.SaveHighScore();
        uiManager?.ShowGameOverScreen(scoreManager.GetScore(), scoreManager.GetHighScore());
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
