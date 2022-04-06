using System;
using System.Collections;
using System.Collections.Generic;
using Enemies.Scripts;
using UnityEngine;

namespace Enemies.Scripts
{
    public class EnemyView : MonoBehaviour
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
    }
}