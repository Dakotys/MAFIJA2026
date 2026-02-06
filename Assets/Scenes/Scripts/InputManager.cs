using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public static Vector2 Movement;
    public GameObject container;

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _esc;

    private bool _isPlaying = true;

    private void Awake()
    {
        _playerInput=GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
        _esc = _playerInput.actions["Escape"];
    }

    // Update is called once per frame
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
        }
    }

    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;
    }
    public void MenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
