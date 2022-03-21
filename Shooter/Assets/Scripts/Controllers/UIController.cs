using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingsPopup settingsPopup;
    private int _score;

    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    void Start()
    {
        _score = 0;
        scoreLabel.text = $"{_score}";
        settingsPopup.Close();
    }

    private void OnEnemyHit()
    {
        _score += 1;
        scoreLabel.text = $"{_score}";
    }
    
    // Метод, вызываемый кнопкой настроек
    public void OnOpenSettings()
    {
        settingsPopup.Open();
    }

    public void OnPointerDown()
    {
        Debug.Log("Pointer down");
    }
}
