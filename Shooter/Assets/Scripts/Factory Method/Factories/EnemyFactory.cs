using System;
using Enemies.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FactoryMethod.Factories
{
    public class EnemyFactory : MonoBehaviour, IEnemiesFactory
    {
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private GameObject _fireBallPrefab;
        [SerializeField] private WeaponData[] _weapons;
        private float _minWallXPos = -23f;
        private float _maxWallXPos = 23f;
        private float _minWallZPos = -30f;
        private float _maxWallZPos = 15f;

        private void Start()
        {
            CreateEnemy();
        }
        public void CreateEnemy()
        {
            var enemyView = Instantiate<EnemyView>(_enemyView);
            enemyView.transform.position = SpawnPoint(_minWallXPos, _maxWallXPos, _minWallXPos, _maxWallZPos);
            float angle = Random.Range(0, 360);
            enemyView.transform.Rotate(0, angle, 0);
            var wanderingAI = new WanderingAI(_fireBallPrefab, _weapons, enemyView);
            var reactiveTarget = new ReactiveTarget(enemyView, wanderingAI);
        }
        
        public Vector3 SpawnPoint(float minWallXPos, float maxWallXPos, float minWallZPos, float maxWallZPos)
        {
            float SpawnX = Random.Range(minWallXPos,maxWallXPos);
            float SpawnZ = Random.Range(minWallZPos, maxWallZPos); 
            return new Vector3(SpawnX, 4, SpawnZ);
        }
        
    }
}