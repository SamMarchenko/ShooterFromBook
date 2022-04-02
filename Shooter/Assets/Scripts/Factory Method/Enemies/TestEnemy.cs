using System;
using UnityEngine;

namespace FactoryMethod.Enemies
{
    public class TestEnemy : IEnemy
    {
        // private int EnemyMaxHp;
        // private float EnemyBaseSpeed;
        // private float EnemyViewingRange;
        //
        // public TestEnemy(int EnemyMaxHp, float EnemyBaseSpeed, float EnemyVewingRange)
        // {
        //     this.EnemyMaxHp = EnemyMaxHp;
        //     this.EnemyBaseSpeed = EnemyBaseSpeed;
        //     this.EnemyViewingRange = EnemyVewingRange;
        // }
        private WanderingAI WanderingAi;
        private ReactiveTarget ReactiveTarget;

        public void Init(WanderingAI wanderingAi, ReactiveTarget reactiveTarget)
        {
            WanderingAi = wanderingAi;
            ReactiveTarget = reactiveTarget;
        }
        
        public void WanderingAI()
        {
            Debug.Log("Do WanderingAI");
        }

        public void ReactToHit()
        {
            Debug.Log("Do ReactToHit");
        }
    }
}