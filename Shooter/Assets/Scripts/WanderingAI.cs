using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private Enemy EnemyData;
    // Эти два поля добавляются перед любыми методами, как и в сценарии SceneController.
    [SerializeField] private GameObject fireballPrefab; 
    private GameObject _fireball;
    // Логическая переменная для слежения состояния персонажа.
   // private bool _alive;  
    
    private void Start()
    {
        //EnemyData.Alive = true;
    }
    void Update()
    {
        if (EnemyData.Alive)
        {
            // Непрерывно движемся вперед в каждои кадре, несмотря на повороты.
            transform.Translate(0, 0, EnemyData.EnemySpeed * Time.deltaTime); 
            // Луч находится в том же положении и нацеливается в том же направлении, что и персонаж.
            var ray = new Ray(transform.position, transform.forward); 
            RaycastHit hit;
            
            // Бросаем луч с описанной вокруг него окружностью.
            if (Physics.SphereCast(ray, 1f, out hit)) 
            {
                GameObject hitObject = hit.transform.gameObject;
                // Игрок распознается тем же способом, что и мишень в сценарии RayShooter.
                if (hitObject.GetComponent<PlayerCharacter>()) 
                {
                    // Та же самая логика с пустым игровым объектом, что и в сценарии SceneController.
                    if (_fireball == null) 
                    {
                        // Метод Instatiate работает так же, как и в сценарии SceneController.
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        // Помещаем огненный шар перед врагом и нацелим в направлении его движения.
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f); 
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < EnemyData.VewingRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
                if (hit.distance < EnemyData.VewingRange)
                {
                    float angle = Random.Range(-110, 110);
                    // Поворот с наполовину случайным выбором направления.
                    transform.Rotate(0, angle, 0); 
                }
            }
        }
    }
    // Открытый метод, позволяющий внешнему коду воздействовать на "живое" состояние.
   /*
    public void SetAlive (bool alive) 
    {
        _alive = alive;
    }
    */
    
}

