using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private Player PlayerData;
    [SerializeField] private Text PlHPLabel;
    private int _playerHP;
    public int CurrentHP
    {
        get {return _playerHP; }
    }
    
    private FPSInput Control;
    private MouseLook MouseObserveX;

    private void Start()
    {
        Control = GetComponent<FPSInput>();
        Control.enabled = true;
        
        MouseObserveX = GetComponent<MouseLook>();
        MouseObserveX.enabled = true;
        
        _playerHP = PlayerData.PlayerHp;
        PlHPLabel.text = $"<color=green>HP: {_playerHP}</color>";
    }

    private void Update()
    {
        if (_playerHP == 0)
        {
            Control.enabled = false;
            MouseObserveX.enabled = false;
        }
    }

    public void Hurt(int damage)
    {
        // Уменьшение здоровья игрока.
        _playerHP = (_playerHP - damage) < 0 ? 0 : (_playerHP - damage);
        PlHPLabel.text = $"<color=green>HP: {_playerHP}</color>";
    }
}
