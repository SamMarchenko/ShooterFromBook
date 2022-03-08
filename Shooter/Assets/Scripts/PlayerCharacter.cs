using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private Player PlayerData;
    private int _playerMaxHP;

    private void Start()
    {
        _playerMaxHP = PlayerData.PlayerHp;
    }

    private void Update()
    {
        if (PlayerData.PlayerHp <= 0)
        {
            Destroy(this.gameObject);
            PlayerData.PlayerHp = _playerMaxHP;
        }
    }

    public void Hurt(int damage)
    {
        // Уменьшение здоровья игрока.
        PlayerData.PlayerHp -= damage;
        Debug.Log("Health = " + PlayerData.PlayerHp);
    }
}
