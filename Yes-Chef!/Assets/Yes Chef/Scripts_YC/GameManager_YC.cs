using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager_YC : MonoBehaviour
{
    public float gameTime = 180;
    public int currentGameScore;

    [Header("UI")]
    public Image gameOverUI;
    public TextMeshProUGUI gameTimerTxt;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI congratsNewScoreText;

    private const string HIGH_SCORE_KEY = "HighScore";
   
    void Update()
    {
        gameTime -= Time.deltaTime;
        gameTimerTxt.text = gameTime.ToString("F0");

        if(gameTime <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        gameOverUI.gameObject.SetActive(true);
        currentScoreText.text = "Current Score: " + currentGameScore.ToString();
        highscoreText.text = "High Score: " + PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0).ToString();

        if (currentGameScore > PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0))
        {
            congratsNewScoreText.gameObject.SetActive(true);
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, currentGameScore);
            PlayerPrefs.Save(); 
        }
    }

    public void AddGameScore(int counterScore)
    {
        currentGameScore += counterScore;
    }
}
