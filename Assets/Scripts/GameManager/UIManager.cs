using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private TextMeshProUGUI hpText;

    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI gameOverHighScoreText;

    [SerializeField] private Button startButton;
    [SerializeField] private Button restartButton;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(RestartGame);

        startMenu.SetActive(true);
        gameOverMenu.SetActive(false);

        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
            highScoreText.text = $"High Score: {scoreManager.GetHighScore()}";
    }

    private void StartGame()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UpdateScoreUI(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void UpdateHPUI(int hp)
    {
        if (hpSlider != null)
            hpSlider.value = hp;
        if (hpText != null)
            hpText.text = $"HP: {hp}";
    }

    public void ShowGameOverScreen(int score, int highScore)
    {
        gameOverMenu.SetActive(true);
        gameOverScoreText.text = $"Score: {score}";
        gameOverHighScoreText.text = $"High Score: {highScore}";
    }

    private void RestartGame()
    {
        GameManager.Instance.RestartGame();
    }
}
