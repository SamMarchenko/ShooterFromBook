using System;
using System.Collections;
using System.Collections.Generic;
using Enemies.Scripts;
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
        private WanderingAI WanderingAi;
        
        public void StartAnimationDie()
        {
            StartCoroutine(Die());
        }

        // Опрокиддывает врага, ждет 1,5 сек и уничтожает его.
        private IEnumerator Die()
        {
            if (this.transform.rotation.x == 0)
            {
                this.transform.Rotate(-75, 0, 0);
                _meshRenderer.material = enemyData.Materials[0];
                yield return new WaitForSeconds(1.5f);
                // Объект может уничтожить себя сам как любой другой объект.
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
                // Непрерывно движемся вперед в каждои кадре, несмотря на повороты.
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
                // Игрок распознается тем же способом, что и мишень в сценарии RayShooter.
                if (hitObject.GetComponent<PlayerCharacter>()) 
                {
                    //todo: НУЖНА ФАБРИКА ФАЕРБОЛОВ
                    // if (_fireball == null)
                    // {
                    //     //_fireball = ;
                    //     _fireball.transform.position = _enemyView.Transform.TransformPoint(Vector3.forward * 1.5f); 
                    //     _fireball.transform.rotation = _enemyView.Transform.rotation;
                    // }
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