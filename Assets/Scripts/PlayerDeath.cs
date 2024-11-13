using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private BodyRotation _bodyRotation;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Animator _animatorCamera;

    void Start()
    {
        _playerHealth.DeathPlayer.AddListener(OnDeath);
    }

    private void OnDeath()
    {
        _playerMove.enabled = false;
        _bodyRotation.enabled = false;
        _animatorCamera.enabled = true;
    }
}
