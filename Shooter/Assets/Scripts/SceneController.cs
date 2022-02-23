using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    
    [SerializeField] private GameObject enemyPrefab;  // сериализованная переменная для связи с объектом - шаблоном

    private GameObject _enemy; // закрытая переменная для слежения за экземпляром врага в сцене


    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject; // Метод, копирующий объект - шаблон
            float SpawnX = Random.Range(-23,23);
            float SpawnZ = Random.Range(-30, 15);
            _enemy.transform.position = new Vector3(SpawnX, 4, SpawnZ);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
