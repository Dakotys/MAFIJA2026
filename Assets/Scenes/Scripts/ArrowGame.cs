using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArrowGame : MonoBehaviour
{
    public float moveSpeed = 500f; // Speed of the arrow
    public TMP_Text resultText; // Assign a TextMeshPro object
    public GameObject safeZone; // Assign the green safe zone
    public float leftBoundary = -300f; // Left edge of movement
    public float rightBoundary = 300f; // Right edge of movement

    private RectTransform arrowTransform;
    private RectTransform safeZoneTransform;
    private bool isMovingRight = true;
    private bool gameOver = false;

    void Start()
    {
        arrowTransform = GetComponent<RectTransform>();
        safeZoneTransform = safeZone.GetComponent<RectTransform>();
        resultText.text = "Press SPACE when the arrow is in the GREEN ZONE!";
    }

    void Update()
    {
        if (gameOver) return;

        // Move the arrow left and right
        float moveDirection = isMovingRight ? 1f : -1f;
        arrowTransform.anchoredPosition += new Vector2(moveDirection * moveSpeed * Time.deltaTime, 0f);

        // Check if the player pressed SPACE
        if (InputManager._space.WasPressedThisFrame())
        {
            if (IsInSafeZone())
            {
                Win();
            }
            else
            {
                Lose();
            }
        }

        // Change direction when hitting boundaries
        if (arrowTransform.anchoredPosition.x > rightBoundary)
            isMovingRight = false;
        else if (arrowTransform.anchoredPosition.x < leftBoundary)
            isMovingRight = true;
    }

    bool IsInSafeZone()
    {
        // Check if the arrow is over the green safe zone
        float arrowX = arrowTransform.anchoredPosition.x;
        float safeZoneX = safeZoneTransform.anchoredPosition.x * 1.5f;
        float safeZoneWidth = safeZoneTransform.rect.width / 2f;

        return Mathf.Abs(arrowX - safeZoneX) < safeZoneWidth;
    }

    void Win()
    {
        gameOver = true;
        resultText.text = "<color=green>YOU WIN! Arrow was in the GREEN ZONE!</color>";
        GetComponent<Image>().color = Color.green;
    }

    void Lose()
    {
        gameOver = true;
        resultText.text = "<color=red>YOU LOSE! Arrow was in the RED ZONE.</color>";
        GetComponent<Image>().color = Color.red;
    }
}
