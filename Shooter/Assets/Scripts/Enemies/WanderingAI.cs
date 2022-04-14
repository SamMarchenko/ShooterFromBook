using System;
using System.Collections;
using System.Collections.Generic;
using Enemies.Scripts;
using FactoryMethod.Factories;
using UnityEngine;
using UnityEngine.VFX;
using Random = UnityEngine.Random;

public class WanderingAI
{
    
    //private GameObject _fireballPrefab; 
    private GameObject _fireball;
    private WeaponData[] _weapons;
    private float _enemyStartSpeed;
    private float _enemyCurrentSpeed;
    private float _currentVewingRange;
    private EnemyView _enemyView;
    
    public WanderingAI (GameObject fireballPrefab, WeaponData[] weapons, EnemyView enemyView)
    {
        _fireball = fireballPrefab;
        _weapons = weapons;
        _enemyView = enemyView;
        Init();
    }
    private void Init()
    {
        _enemyStartSpeed = _enemyView.EnemyData.EnemySpeed;
        _enemyCurrentSpeed = _enemyStartSpeed;
        _currentVewingRange = _enemyView.EnemyData.VewingRange;
    }
    // void Awake()
    // {
    //     Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    // }
    // void OnDestroy()
    // {
    //     Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    // }
    
    
    private void OnSpeedChanged(float value)
    {
        _enemyCurrentSpeed = _enemyStartSpeed * value;
    }
}

