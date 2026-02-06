using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceSpamMinigame : MonoBehaviour
{
    public Slider progressBar; // Assign in Inspector
    public float fillAmountPerPress = 0.1f; // How much the bar fills per Space press
    public float timeLimit = 10f; // Time limit for the minigame
    public int goalProgress = 10; // Progress needed to win
    public float regressAmountPerSecond = 0.05f;

    private float currentProgress = 0f;
    private float timer;
    private bool isGameOver = false;

    void Start()
    {
        timer = timeLimit;
        progressBar.maxValue = goalProgress;
        progressBar.value = 0f;
    }

    void Update()
    {
        if (isGameOver) return;

        currentProgress -= regressAmountPerSecond * Time.deltaTime;
        currentProgress = Mathf.Max(currentProgress, 0f); // Don't go below 0
        progressBar.value = currentProgress;

        // Count down the timer
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            GameOver(false); // Player loses if time runs out
            return;
        }

        // Detect Space key press
        if (InputManager._space.WasPressedThisFrame())
        {
            currentProgress += fillAmountPerPress;
            progressBar.value = currentProgress;

            // Check if the player won
            if (currentProgress >= goalProgress)
            {
                GameOver(true); // Player wins
            }
        }
    }

    void GameOver(bool isWin)
    {
        isGameOver = true;
        if (isWin)
        {
            Debug.Log("You win!");
            // Load next scene or show win screen
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            Debug.Log("You lose!");
            // Load game over scene
            SceneManager.LoadScene("LoseScene");
        }
    }
}
