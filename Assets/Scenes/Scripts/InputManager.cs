using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public static Vector2 Movement;
    public static int AreaScene = -1;  // Set by DetectionArea

    public GameObject container;

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _esc;
    private InputAction _space;

    private bool _isPlaying = true;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
        _esc = _playerInput.actions["Escape"];
        _space = _playerInput.actions["Space"];
    }

    private void Update()
    {
        if (_esc.WasPressedThisFrame())
        {
            if (_isPlaying)
            {
                container.SetActive(true);
                Time.timeScale = 0;
                _isPlaying = false;
            }
            else
            {
                container.SetActive(false);
                Time.timeScale = 1;
                _isPlaying = true;
            }
        }

        if (Time.timeScale == 1)
        {
            Movement = _moveAction.ReadValue<Vector2>();

            // Load area scene on Space if player in DetectionArea
            if (AreaScene != -1 && _space.WasPressedThisFrame())
            {
                SceneManager.LoadSceneAsync(AreaScene);
            }
        }
    }

    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;
        _isPlaying = true;
    }

    public void MenuButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;
        _isPlaying = true;
        SceneManager.LoadScene("Menu");
    }
}
