using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _maxHealth = 8;

    [SerializeField] private AudioSource _addHealthSound;

    [SerializeField] private HealthUI _healthUI;
    [SerializeField] private Menu _menu;

    private float _yPositionForDie = -18f;
    private bool _invulnerable = false;

    [SerializeField] private UnityEvent _eventOnTakeDamage;

    private void Start()
    {
        _healthUI.Setup(_maxHealth);
        _healthUI.DisplayHealth(_health);
    }

    private void Update()
    {
            if (transform.position.y < _yPositionForDie)
            {
                Die();
            }
    }

    public void TakeDamage(int damageValue)
    {
        if (_invulnerable == false)
        {
            _health -= damageValue;
            if (_health <= 0)
            {
                Die();
            }
            _invulnerable = true;
            Invoke(nameof(StopInvulnerable), 1f);
            _healthUI.DisplayHealth(_health);
            _eventOnTakeDamage.Invoke();
        }
    }

    private void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int addValueHealth)
    {
        _health += addValueHealth;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        _addHealthSound.Play();
        _healthUI.DisplayHealth(_health);
    }
    private void Die()
    {
        //Почему не работает timeScale?
        Time.timeScale = 0.01f;
        _menu.LoseWindow();
    }
}
