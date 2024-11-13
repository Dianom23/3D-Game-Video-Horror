using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuPanel;
    private bool _isPaused;

    void Start()
    {
        SetPause(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (_isPaused)
                SetPause(false);
            else
                SetPause(true);
    }

    public void SetPause(bool value)
    {
        if (value == true)
        {
            _pauseMenuPanel.SetActive(true);
            _isPaused = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            _pauseMenuPanel.SetActive(false);
            _isPaused = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
