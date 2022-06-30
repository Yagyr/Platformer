using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _speed;
    
    [SerializeField] private float _jointSpring = 100f;
    [SerializeField] private float _jointDamper = 5f;
    [SerializeField] private float _jointMaxDistance = 3f;
    [SerializeField] private float _shotDistance = 7f;
    
    private float _lengthRope;

    [SerializeField] private Transform _ropeStart;

    [SerializeField] private RopeState _currentRopeState;
    [SerializeField] private RopeRenderer _ropeRenderer;
    [SerializeField] private PlayerMove _playerMove;

    private SpringJoint _springJoint;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shot();
        }

        if (_currentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(_ropeStart.position, _hook.transform.position);
            if (distance >= _shotDistance)
            {
                _hook.gameObject.SetActive(false);
                _currentRopeState = RopeState.Disabled;
                _ropeRenderer.Hide();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentRopeState == RopeState.Active)
            {
                if (_playerMove.grounded == false)
                {
                    _playerMove.Jump();
                }
            }
            DestroySpringJoint();
        }

        if (_currentRopeState == RopeState.Fly || _currentRopeState == RopeState.Active)
        {
            _ropeRenderer.Draw(_ropeStart.position, _hook.transform.position, _lengthRope);
        }
    }

    private void Shot()
    {
        _lengthRope = 1f;
        if (_springJoint)
        {
            Destroy(_springJoint);
        }
        _hook.gameObject.SetActive(true);
        _hook.StopFixJoint();
        _hook.transform.position = _spawn.position;
        _hook.transform.rotation = _spawn.rotation;
        _hook.rigidbody.velocity = _spawn.forward * _speed;
        _currentRopeState = RopeState.Fly;
    }

    private void DestroySpringJoint()
    {
        if (_springJoint)
        {
            Destroy(_springJoint);
            _currentRopeState = RopeState.Disabled;
            _hook.gameObject.SetActive(false);
            _ropeRenderer.Hide();
        }
    }

    public void CreateSpringJoint()
    {
        if (_springJoint == null)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();
            _springJoint.connectedBody = _hook.rigidbody;
            _springJoint.anchor = _ropeStart.localPosition;
            _springJoint.autoConfigureConnectedAnchor = false;
            _springJoint.connectedAnchor = Vector3.zero;
            _springJoint.spring = _jointSpring;
            _springJoint.damper = _jointDamper;
            _springJoint.maxDistance = _jointMaxDistance;

            _lengthRope = Vector3.Distance(_ropeStart.position, _hook.transform.position);

            _currentRopeState = RopeState.Active;
        }
    }
}
