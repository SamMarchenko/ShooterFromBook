using System.Collections;
using System.Collections.Generic;
using Enemies.Scripts;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private GameObject _enemy;
    [SerializeField] private Enemy[] _enemies;

    void Update()
    {
        if (_enemy == null)
        {
            // Метод, копирующий объект - шаблон.
            _enemy = Instantiate(_enemyPrefab) as GameObject;
            _enemy.GetComponent<EnemyController>().EnemyData = _enemies[Random.Range(0, _enemies.Length)];
            float SpawnX = Random.Range(-23,23);
            float SpawnZ = Random.Range(-30, 15);
            _enemy.transform.position = new Vector3(SpawnX, 4, SpawnZ);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
