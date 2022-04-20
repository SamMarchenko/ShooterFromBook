using System;
using System.Collections;
using FactoryMethod.Factories;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Scripts
{
    public class EnemyView : MonoCache
    {
        public Transform Transform => transform;
        [SerializeField] private EnemyData enemyData;
        public EnemyData EnemyData => enemyData;
        [SerializeField] private MeshRenderer _meshRenderer;
        public MeshRenderer MeshRenderer => _meshRenderer;
        private WanderingAI _wanderingAI;
        private WeaponFactory _weaponFactory;

        public void Init(WanderingAI wanderingAi)
        {
            _wanderingAI = wanderingAi;
        }

        public void StartAnimationDie()
        {
            StartCoroutine(Die());
        }
        
        private IEnumerator Die()
        {
            if (this.transform.rotation.x == 0)
            {
                this.transform.Rotate(-75, 0, 0);
                _meshRenderer.material = enemyData.Materials[0];
                yield return new WaitForSeconds(1.5f);
                Destroy(this.gameObject);
            }
        }
        public override void OnTick()
        {
            EnemyMove();
        }
        public void EnemyMove()
        { 
            if (enemyData.Alive) 
            {
                transform.Translate(0, 0, enemyData.EnemySpeed * Time.deltaTime);
                var ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                EnemyVision(ray,out hit);
            } 
        }
        public void EnemyVision(Ray ray, out RaycastHit hit)
        {
            if (Physics.SphereCast(ray, 1f, out hit)) 
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerView>()) 
                {
                    Debug.Log("STRELYAU");
                    _wanderingAI.Shoot();
                }
                else if (hit.distance < enemyData.VewingRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
        
    }
}