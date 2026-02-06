using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    [SerializeField] private int sceneToLoadIndex = 0;  // Set in Inspector


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InputManager.AreaScene = sceneToLoadIndex;  // Use class name for static
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InputManager.AreaScene = -1;  // Use class name
        }
    }
}
