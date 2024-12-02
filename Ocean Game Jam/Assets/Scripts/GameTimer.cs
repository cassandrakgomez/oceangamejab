using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class GameTimer : MonoBehaviour
{
    private float elapsedTime = 0f; // Tracks elapsed time
    private bool isGameOver = false; // Tracks if the player is alive
    private float bestTime; // Best time from previous runs

    [SerializeField] TextMeshProUGUI timerText; // Reference to UI Text (Optional)
    [SerializeField] TextMeshProUGUI bestTimeText; // Reference to Best Time UI Text (Optional)

    void Start()
    {
        // Initialize the best time (if any) from PlayerPrefs
        bestTime = PlayerPrefs.GetFloat("BestTime", 0f);
    }

    void Update()
    {
        if (!isGameOver)
        {
            elapsedTime += Time.deltaTime; // Increment elapsed time
        }
    }

    public void GameOver()
    {
        // Call this method when the player dies
        isGameOver = true;

        // Check if the current run is the best time
        if (elapsedTime > bestTime)
        {
            bestTime = elapsedTime;

            // Save the new best time to PlayerPrefs
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        if (bestTimeText != null) bestTimeText.text = $"Best: {bestTime:F2} s"; // Update the best time UI
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    public float GetBestTime()
    {
        return bestTime;
    }

}
