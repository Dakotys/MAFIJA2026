using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class miniplayer_controller : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public static bool isDead = false;

    // Timer variables
    private float timer = 20f;
    private bool timerActive = true;

    // UI reference
    public TextMeshProUGUI timerText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 20f;
        timerActive = true;
    }

    void Update()
    {
        // Timer countdown
        if (timerActive)
        {
            timer -= Time.deltaTime;

            // Update UI text
            if (timerText != null)
            {
                timerText.text = "Time left: " + Mathf.Ceil(timer).ToString();
            }

            // Check if timer reached zero and player is still alive
            if (timer <= 0f && !isDead)
            {
                timerActive = false;
                LoadSceneAndRestoreHealth();
                return;
            }
        }

        // Movement code
        float moveHorizontal = InputManager.Movement.x;
        float moveVertical = InputManager.Movement.y;
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Normalize the vector to prevent faster diagonal movement
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }
        rb.linearVelocity = movement * speed;

        // Death check
        if (isDead)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void LoadSceneAndRestoreHealth()
    {
        // Get max health and restore to full
        //int maxHealth = TheState.GetMaxHealth();
        //TheState.SetHealth(maxHealth);

        // Load scene 0
        SceneManager.LoadScene(0);
    }
}
