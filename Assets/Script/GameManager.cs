using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject gameOverUI;
    public TextMeshProUGUI gameplayScoreText; 
    public TextMeshProUGUI finalScoreText;    
    public TextMeshProUGUI highScoreText;     

    private float timeSurvived = 0f;
    private int pillsTaken = 0;
    private bool isGameOver = false;
    void Start()
    {
        Time.timeScale = 1f; // start time for reset
        isGameOver = false;
        if (gameOverUI != null) gameOverUI.SetActive(false);
    }
    public void StartGame() {
        SceneManager.LoadScene(1);
    }
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
    }
   
    // Update is called once per frame
    void Update()
    {
        if (!isGameOver) {
            timeSurvived += Time.deltaTime;
            UpdateGameplayUI();
        }
    }
    public void TriggerGameOver() {
        if (isGameOver) return;
        isGameOver = true;

        if (gameOverUI != null) {
            gameOverUI.SetActive(true);
        }


        Time.timeScale = 0f; // stop time
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        CalculateAndSaveScore();
    }
    public void AddPill() {
        pillsTaken++;
        UpdateGameplayUI();
    }
    void UpdateGameplayUI() {
        if (gameplayScoreText != null) {
            int currentSeconds = Mathf.FloorToInt(timeSurvived);
            int currentScore = currentSeconds * pillsTaken;
            gameplayScoreText.text = $"Time: {currentSeconds}s  Pills: {pillsTaken}  Score: {currentScore}";
        }
    }
    void CalculateAndSaveScore() {
        int finalSeconds = Mathf.FloorToInt(timeSurvived);
        int finalScore = finalSeconds * pillsTaken;

        int savedHighScore = PlayerPrefs.GetInt("BestScore", 0);

        if (finalScore > savedHighScore) {
            savedHighScore = finalScore;
            PlayerPrefs.SetInt("BestScore", savedHighScore);
            PlayerPrefs.Save(); // Hard Drive save
        }

        // Update the Game Over UI text
        if (finalScoreText != null)
            finalScoreText.text = $"Final Score: {finalScore}";

        if (highScoreText != null)
            highScoreText.text = $"High Score: {savedHighScore}";
    }
}
