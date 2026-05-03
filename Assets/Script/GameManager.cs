using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject gameOverUI;
    void Start()
    {
        Time.timeScale = 1f; // start time for reset
        if (gameOverUI != null) {
            gameOverUI.SetActive(false);
        }
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
    public void TriggerGameOver() {
        Debug.Log("Game Over Triggered!");

        if (gameOverUI != null) {
            gameOverUI.SetActive(true);
        }

        Time.timeScale = 0f; // stop time
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
