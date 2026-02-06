using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    [SerializeField] private int sceneToLoadIndex = 0;  // Set in Inspector

    private bool playerInside = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter");
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            InputManager.AreaScene = sceneToLoadIndex;  // Use class name for static
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            InputManager.AreaScene = -1;  // Use class name
        }
    }
}
