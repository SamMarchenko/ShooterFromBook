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
    private int _playerMaxHP;

    private void Start()
    {
        _playerMaxHP = PlayerData.PlayerHp;
        PlHPLabel.text = $"<color=green>HP: {PlayerData.PlayerHp}</color>";
    }

    private void Update()
    {
        if (PlayerData.PlayerHp == 0)
        {
            Destroy(this.gameObject);
            PlayerData.PlayerHp = _playerMaxHP;
        }
    }

    public void Hurt(int damage)
    {
        // Уменьшение здоровья игрока.
        PlayerData.PlayerHp = (PlayerData.PlayerHp - damage) < 0 ? 0 : (PlayerData.PlayerHp - damage);
        PlHPLabel.text = $"<color=green>HP: {PlayerData.PlayerHp}</color>";
    }
}
