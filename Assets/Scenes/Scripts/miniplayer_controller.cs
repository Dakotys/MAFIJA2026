using UnityEngine;
using UnityEngine.SceneManagement;

public class miniplayer_controller : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with a specific tag or layer
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(3); 
            Debug.Log("Player hit an enemy!");
            // Handle collision (e.g., take damage, play sound)
        }
    }

    void Update()
    {
        float moveHorizontal = InputManager.Movement.x ;
        float moveVertical = InputManager.Movement.y;
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        // Normalize the vector to prevent faster diagonal movement
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }
        rb.linearVelocity = movement * speed;
    }
    
}
