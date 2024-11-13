using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public UnityEvent DeathPlayer = new UnityEvent();

    [SerializeField] private int _health; // Текущее кол-во жизней
    [SerializeField] private int _maxHealth; // Максимальное кол-во жизней
    [SerializeField] private Slider _healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        _health = _maxHealth;
        UpdateSlider();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if( _health < 0 )
            _health = 0;

        if(_health <= 0)
            DeathPlayer?.Invoke();

        UpdateSlider();
    }

    private void UpdateSlider()
    {
        _healthSlider.value = (float)_health / _maxHealth;
    }
}
