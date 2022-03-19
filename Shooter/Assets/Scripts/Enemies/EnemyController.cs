using UnityEngine;

namespace Enemies.Scripts
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyData;
        public Enemy EnemyData 
        {
            get { return _enemyData; }
            set {_enemyData = value ; }
        }
    }
}