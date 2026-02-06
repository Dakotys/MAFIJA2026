using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Vector2 _movement;

    private Rigidbody2D _rb;
    private Animator _animator;

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";


    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        // Load saved position
        LoadPosition();
    }

    void Update()
    {
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        _rb.linearVelocity = _movement * _moveSpeed;

        _animator.SetFloat(_horizontal, _movement.x);
        _animator.SetFloat(_vertical, _movement.y);

        if (_movement != Vector2.zero)
        {
            _animator.SetFloat(_lastVertical, _movement.y);
            _animator.SetFloat(_lastHorizontal, _movement.x);
        }

        // Wrap coordinates
        Vector2 position = transform.position;

        // X coordinate wrapping
        if (position.x > 60f)
        {
            position.x -= 61f;
        }
        else if (position.x < -16f)
        {
            position.x += 61f;
        }

        // Y coordinate wrapping
        if (position.y > 26f)
        {
            position.y -= 41f;
        }
        else if (position.y < -26f)
        {
            position.y += 41f;
        }

        transform.position = position;
    }

    private void OnDestroy()
    {
        // Save position when player is destroyed (scene change, game quit, etc.)
        SavePosition();
    }

    private void OnApplicationQuit()
    {
        // Save position when quitting
        SavePosition();
    }

    private void SavePosition()
    {
        GlobalVars.LastPlayerPosition = transform.position;
    }

    private void LoadPosition()
    {
        // Only load if there's a saved position (not Vector3.zero)
        if (GlobalVars.LastPlayerPosition != Vector2.zero)
        {
            transform.position = GlobalVars.LastPlayerPosition;
        }
    }
}
