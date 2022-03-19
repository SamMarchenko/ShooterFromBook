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
    [SerializeField] private FPSInput _FpsInput;
    [SerializeField] private MouseLook _MouseLook;
    public int CurrentHP { get; private set; }
    
    private void Start()
    {
        _FpsInput.enabled = true;
        _MouseLook.enabled = true;
        CurrentHP = PlayerData.PlayerHp;
        PlHPLabel.text = $"<color=green>HP: {CurrentHP}</color>";
    }
    
    public void Hurt(int damage)
    {
        // Уменьшение здоровья игрока.
        CurrentHP = (CurrentHP - damage) < 0 ? 0 : (CurrentHP - damage);
        PlHPLabel.text = $"<color=green>HP: {CurrentHP}</color>";
        if (CurrentHP != 0) return;
        DeathPlayer();
    }
    
    public void DeathPlayer()
    {
        _FpsInput.enabled = false;
        _MouseLook.enabled = false;
    }
}
