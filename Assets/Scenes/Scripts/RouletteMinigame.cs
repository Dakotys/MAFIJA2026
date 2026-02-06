using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // Add this for TextMeshPro

public class RouletteMinigame : MonoBehaviour
{
    public AudioClip spinSound; // Assign in Inspector
    public AudioClip winSound;  // Assign in Inspector
    public AudioClip loseSound; // Assign in Inspector
    public float spinDuration = 3f; // How long the wheel spins
    public float maxSpinSpeed = 720f; // Degrees per second
    public TMP_Text resultText; // Change from Text to TMP_Text

    private bool isSpinning = false;
    private float timer = 0f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        resultText.text = "Click the wheel to spin!";
    }

    void Update()
    {
        if (isSpinning)
        {
            timer += Time.deltaTime;
            float speed = Mathf.Lerp(maxSpinSpeed, 0f, timer / spinDuration);
            transform.Rotate(0f, 0f, -speed * Time.deltaTime);

            if (timer >= spinDuration)
            {
                isSpinning = false;
                timer = 0f;
                ShowResult();
            }
        }
    }

    public void OnWheelClick()
    {
        Debug.Log("Button clicked!"); // Check the Console for this message
        if (isSpinning) return;
        isSpinning = true;
        timer = 0f;
        audioSource.PlayOneShot(spinSound);
        if (resultText != null)
            resultText.text = "Spinning...";
    }



    void ShowResult()
    {
        bool isRed = Random.Range(0, 2) == 0;
        resultText.text = isRed ? "<color=red>RED (You Win!)</color>" : "<color=black>BLACK (You Lose!)</color>";
        audioSource.PlayOneShot(isRed ? winSound : loseSound);
        Invoke("LoadResultScene", 2f);
    }

    void LoadResultScene()
    {
        string result = resultText.text;
        if (result.Contains("Win"))
        {
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
