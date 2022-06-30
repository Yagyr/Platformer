using UnityEngine;

public class LootHeal : MonoBehaviour
{
    [SerializeField] private int _addHealth = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.AddHealth(_addHealth);
            Destroy(gameObject);
        }
    }
}
