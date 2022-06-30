using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private FixedJoint _fixedJoint;

    [SerializeField] private Collider _collider;
    [SerializeField] private Collider _playerCollider;
    [SerializeField] private RopeGun _ropeGun;
    
    public Rigidbody rigidbody;

    private void Start()
    {
        Physics.IgnoreCollision(_collider, _playerCollider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();
            if (collision.rigidbody == null)
            {
                _fixedJoint.connectedBody = collision.rigidbody;
            }
            _ropeGun.CreateSpringJoint();
        }
    }

    public void StopFixJoint()
    {
        if (_fixedJoint)
        {
            Destroy(_fixedJoint);
        }
    }
}
