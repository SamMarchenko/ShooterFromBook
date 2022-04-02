using System;
using Enemies.Scripts;
using FactoryMethod.Enemies;
using UnityEngine;

namespace FactoryMethod.Factories
{
    public class TestFactory : MonoBehaviour , IEnemiesFactory
    {
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private GameObject _fireBallPrefab;
        [SerializeField] private Weapon[] _weapons;

        private void Start()
        {
            CreateMock();
        }

        public IEnemy Create()
        {
            Debug.Log("Create smth");
            return new TestEnemy();
        }
        
        public void CreateMock()
        {
            var enemyView = Instantiate<EnemyView>(_enemyView);
            var wanderingAI = new WanderingAI(_fireBallPrefab, _weapons, enemyView);
            var reactiveTarget = new ReactiveTarget(enemyView, wanderingAI);
        }
    }
}