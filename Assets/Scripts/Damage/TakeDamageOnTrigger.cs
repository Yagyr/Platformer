using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private int _damageValue = 1;

    [SerializeField] private bool _dieOnAmyCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<Bullet>())
            {
                _enemyHealth.TakeDamage(_damageValue);
            }
        }

        if (_dieOnAmyCollision)
        {
            if (other.isTrigger == false)
            {
                _enemyHealth.TakeDamage(10000);
            }
        }
    }
}
