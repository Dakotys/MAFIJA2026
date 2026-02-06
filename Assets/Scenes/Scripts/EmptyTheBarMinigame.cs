using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EmptyTheBarMinigame : MonoBehaviour
{
    public Slider progressBar; // Assign in Inspector
    public float emptyAmountPerPress = 0.1f; // How much the bar empties per Space press
    public float timeLimit = 10f; // Time limit for the minigame
    public float refillAmountPerSecond = 0.02f; // How fast the bar refills (makes it harder)

    private float currentProgress;
    private float timer;
    private bool isGameOver = false;

    void Start()
    {
        timer = timeLimit;
        progressBar.maxValue = 1f; // Bar max value is 1 (100%)
        progressBar.value = 1f; // Start with a full bar
        currentProgress = 1f;
    }

    void Update()
    {
        if (isGameOver) return;

        // The bar slowly refills over time (makes the game harder)
        currentProgress += refillAmountPerSecond * Time.deltaTime;
        currentProgress = Mathf.Min(currentProgress, 1f); // Don't exceed max
        progressBar.value = currentProgress;

        // Count down the timer
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            // Player loses if the bar isn't empty when time runs out
            GameOver(currentProgress <= 0f);
            return;
        }

        // Detect Space key press to empty the bar
        if (InputManager._space.WasPressedThisFrame())
        {
            currentProgress -= emptyAmountPerPress;
            currentProgress = Mathf.Max(currentProgress, 0f); // Don't go below 0
            progressBar.value = currentProgress;

            // Player wins if the bar is emptied
            if (currentProgress <= 0f)
            {
                GameOver(true);
            }
        }
    }

    void GameOver(bool isWin)
    {
        isGameOver = true;
        if (isWin)
        {
            Debug.Log("You win! Bar emptied in time!");
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            Debug.Log("You lose! Bar wasn't emptied in time.");
            SceneManager.LoadScene("LoseScene");
        }
    }
}
