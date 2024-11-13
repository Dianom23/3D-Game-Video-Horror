using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private PauseMenu _pauseMenu;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _playerHealth.DeathPlayer.AddListener(OnDeath);
    }

    private void OnDeath()
    {
        StartCoroutine(OnDeathCoroutine());
    }

    private IEnumerator OnDeathCoroutine()
    {
        yield return new WaitForSeconds(3);
        _pauseMenu.SetPause(true);
        _pauseMenu.enabled = false;
    }
}
