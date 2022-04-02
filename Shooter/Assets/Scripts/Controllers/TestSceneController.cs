using FactoryMethod;
using FactoryMethod.Enemies;
using FactoryMethod.Factories;
using UnityEngine;

namespace Controllers
{
    public class TestSceneController
    {
        private IEnemiesFactory factory;
        public IEnemy NeedEnemy()
        {
                IEnemy enemy = new TestEnemy();
                enemy = factory.Create();
                return enemy;
        }
    }
}