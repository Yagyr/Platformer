using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    [SerializeField] private int _numberOfBullets;
    [SerializeField] private Text _bulletsText;
    [SerializeField] private PlayerArmory _playerArmory;

    public override void Shot()
    {
        base.Shot();
        _numberOfBullets--;
        UpdateText();
        if (_numberOfBullets == 0)
        {
            _playerArmory.TakeGunByIndex(0);    
        }
    }

    public override void Activate()
    {
        base.Activate();
        _bulletsText.enabled = true;
        UpdateText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _bulletsText.enabled = false;
    }

    private void UpdateText()
    {
        _bulletsText.text = "Пули: " + _numberOfBullets.ToString();
    }

    public override void AddBullets(int numberOfBullets)
    {
        base.AddBullets(numberOfBullets);
        _numberOfBullets += numberOfBullets;
        UpdateText();
    }
}
