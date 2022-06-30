using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullets : MonoBehaviour
{
    [SerializeField]  int _indexGun;
    [SerializeField]  int _numberOfBullets;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerArmory playerArmory))
        {
            playerArmory.AddBullets(_indexGun, _numberOfBullets);
            Destroy(gameObject);
        }
    }
}
