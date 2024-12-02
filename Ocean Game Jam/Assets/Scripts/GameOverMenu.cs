using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; 

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverUI; // The Game Over Canvas
    public TextMeshProUGUI currentTimeText; // UI Text for the current time
    public TextMeshProUGUI bestTimeText; // UI Text for the best time

    public void ShowGameOver(float currentTime, float bestTime)
    {
        // Display Game Over screen
        gameOverUI.SetActive(true);
        Time.timeScale = 0f; // Freeze game time

        // Update the UI texts
        currentTimeText.text = $"Time: {currentTime:F2} s";
        bestTimeText.text = $"Best: {bestTime:F2} s";
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Reset time scale
        SceneManager.LoadScene("MainMenu"); // Load Main Menu scene
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit(); // Quit the application
    }
}
