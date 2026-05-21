using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0;
    private int highScore = 0;
    private const string HIGH_SCORE_KEY = "HighScore";

    private void Awake()
    {
        LoadHighScore();
    }

    public void AddScore(int points)
    {
        currentScore += points;
    }

    public int GetScore()
    {
        return currentScore;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void SaveHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
            PlayerPrefs.Save();
        }
    }

    public void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
    }
}
