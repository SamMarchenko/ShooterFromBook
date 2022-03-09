using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // Сериализованная переменная для связи с объектом - шаблоном.
    [SerializeField] private GameObject _enemyPrefab;  
    // Закрытая переменная для слежения за экземпляром врага в сцене.
    private GameObject _enemy;
    
    [SerializeField] private Enemy[] _enemies;

    void Update()
    {
        if (_enemy == null)
        {
            // Метод, копирующий объект - шаблон.
            _enemy = Instantiate(_enemyPrefab) as GameObject;
            // ПРОДУМАТЬ.
            _enemy.GetComponent<WanderingAI>().EnemyData = _enemies[Random.Range(0, _enemies.Length)];
            float SpawnX = Random.Range(-23,23);
            float SpawnZ = Random.Range(-30, 15);
            _enemy.transform.position = new Vector3(SpawnX, 4, SpawnZ);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
