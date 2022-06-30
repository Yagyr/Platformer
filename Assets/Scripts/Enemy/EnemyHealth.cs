using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 1;
    
    [SerializeField] private UnityEvent _eventOnTakeDamage;
    [SerializeField] private UnityEvent _eventOnDie;
    public void TakeDamage(int damageValue)
    {
        _health -= damageValue;
        if(_health <= 0)
        {
            Die();
        }
        else
        {
            _eventOnTakeDamage.Invoke();
        }
    }

    private void Die()
    {
        _eventOnDie.Invoke();
        Destroy(gameObject);
    }
}
