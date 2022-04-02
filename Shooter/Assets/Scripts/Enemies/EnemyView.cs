using System.Collections;
using System.Collections.Generic;
using Enemies.Scripts;
using UnityEngine;

namespace Enemies.Scripts
{
    public class EnemyView : MonoBehaviour
    {
        public Transform Transform => transform;
        [SerializeField] private Enemy _enemy;
        public Enemy Enemy => _enemy;
        [SerializeField] private MeshRenderer _meshRenderer;
        public MeshRenderer MeshRenderer => _meshRenderer;

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
                _meshRenderer.material = _enemy.Materials[0];
                yield return new WaitForSeconds(1.5f);
                // Объект может уничтожить себя сам как любой другой объект.
                Destroy(this.gameObject);
            }
        }
    }
}