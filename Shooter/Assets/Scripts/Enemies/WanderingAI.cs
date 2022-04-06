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
    // Эти два поля добавляются перед любыми методами, как и в сценарии SceneController.
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
    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    
    void EnemyMove()
    {
        if (_enemyView.EnemyData.Alive && (_enemyView.Transform.position.x == 0))
        {
            // Непрерывно движемся вперед в каждои кадре, несмотря на повороты.
            _enemyView.Transform.Translate(0, 0, _enemyCurrentSpeed * Time.deltaTime); 
            // Луч находится в том же положении и нацеливается в том же направлении, что и персонаж.
            var ray = new Ray(_enemyView.Transform.position, _enemyView.Transform.forward); 
            RaycastHit hit;
            
            // Бросаем луч с описанной вокруг него окружностью.
            if (Physics.SphereCast(ray, 1f, out hit)) 
            {
                GameObject hitObject = hit.transform.gameObject;
                // Игрок распознается тем же способом, что и мишень в сценарии RayShooter.
                if (hitObject.GetComponent<PlayerCharacter>()) 
                {
                   //todo: НУЖНА ФАБРИКА ФАЕРБОЛОВ
                    // if (_fireball == null)
                    // {
                    //
                    //     //_fireball = ;
                    //     
                    //     _fireball.transform.position = _enemyView.Transform.TransformPoint(Vector3.forward * 1.5f); 
                    //     _fireball.transform.rotation = _enemyView.Transform.rotation;
                    // }
                }
                else if (hit.distance < _currentVewingRange)
                {
                    float angle = Random.Range(-110, 110);
                    _enemyView.Transform.Rotate(0, angle, 0);
                }
                // Не понятно, зачем дублируется if
                // if (hit.distance < _currentVewingRange)
                // {
                //     float angle = Random.Range(-110, 110);
                //     // Поворот с наполовину случайным выбором направления.
                //     _enemyView.Transform.Rotate(0, angle, 0); 
                // }
            }
        }
    }
    private void OnSpeedChanged(float value)
    {
        _enemyCurrentSpeed = _enemyStartSpeed * value;
    }
}

