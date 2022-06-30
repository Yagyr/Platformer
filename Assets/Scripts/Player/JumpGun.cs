using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class JumpGun : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private float _jumpForce = 1f;
    [SerializeField] private Transform _spawn;
    [SerializeField] private Gun _pistol;
    [SerializeField] private ChargeIcon _chargeIcon;

    [SerializeField] private float _maxCharge = 3f;
    private float _currentCharge;

    private bool _isCharged;

    private void Update()
    {
        if (_isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _playerRigidbody.AddForce(-_spawn.forward * _jumpForce, ForceMode.VelocityChange);
                _pistol.Shot();
                _chargeIcon.StartCharge();
                _isCharged = false;
                _currentCharge = 0f;
            }
        }
        else
        {
            _currentCharge += Time.unscaledDeltaTime;
            _chargeIcon.SetChargeValue(_currentCharge, _maxCharge);
            if (_currentCharge >= _maxCharge)
            {
                _chargeIcon.StopCharge();
                _isCharged = true;
            }
        }
    }
}
