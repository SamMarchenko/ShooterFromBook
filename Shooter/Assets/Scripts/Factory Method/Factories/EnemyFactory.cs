using Enemies.Scripts;
using UnityEngine;
using Weapons;
using Random = UnityEngine.Random;

namespace FactoryMethod.Factories
{
    public class EnemyFactory : MonoBehaviour, IEnemiesFactory
    {
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private WeaponView _fireBallPrefab;
        [SerializeField] private WeaponData[] _weapons;
        [SerializeField] private WeaponFactory _weaponFactory;
        private float _minWallXPos = -20f;
        private float _maxWallXPos = 20f;
        private float _minWallZPos = -20f;
        private float _maxWallZPos = 20f;

        private void Start()
        {
            CreateEnemy();
        }
        
        public void CreateEnemy()
        {
            var wanderingAI = new WanderingAI(_fireBallPrefab, _weapons,_weaponFactory);
            var enemyView = Instantiate<EnemyView>(_enemyView);
            enemyView.transform.position = SpawnPoint(_minWallXPos, _maxWallXPos, _minWallZPos, _maxWallZPos);
            enemyView.Init(wanderingAI);
            float angle = Random.Range(0, 360);
            enemyView.transform.Rotate(0, angle, 0);
            var reactiveTarget = new ReactiveTarget(enemyView, wanderingAI);
        }
        
        public Vector3 SpawnPoint(float minWallXPos, float maxWallXPos, float minWallZPos, float maxWallZPos)
        {
            float SpawnX = Random.Range(minWallXPos,maxWallXPos);
            float SpawnZ = Random.Range(minWallZPos, maxWallZPos); 
            return new Vector3(SpawnX, 1, SpawnZ);
        }
        
    }
}