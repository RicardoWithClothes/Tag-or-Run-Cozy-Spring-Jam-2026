using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject gameOverUI;

    [Header("Sound Elements")]
    public AudioSource mainTheme;

    void Start()
    {
        //mainTheme = GetComponent<AudioSource>();

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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //mainTheme.pitch = 1.15f;
    }
    // Update is called once per frame
    void Update()
    {
        mainTheme.pitch = MathF.Sin(MathF.Sqrt(2 * FindObjectOfType<PillBar>().fillAmount)) + 0.2f;
    }
}
