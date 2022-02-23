using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{

    public float speed = 3.0f;         //значения для скорость движения и
    public float obstacleRange = 5.0f; //расстояния, с которого начинается реакция на препятствия
    private bool _alive;   // логическая переменная для слежения состояния персонажа

    [SerializeField] private GameObject fireballPrefab; //  Эти два поля добавляются перед любыми методами, как и в сценарии SceneController
    private GameObject _fireball;                       //
    

    private void Start()
    {
        _alive = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime); // непрерывно движемся вперед в каждои кадре, несмотря на повороты

            Ray ray = new Ray(transform.position, transform.forward); // луч находится в том же положении и нацеливается в том же направлении, что и персонаж
            RaycastHit hit;

            if (Physics.SphereCast(ray, 1f, out hit)) //  бросаем луч с описанной вокруг него окружностью
            {
                GameObject hitObject = hit.transform.gameObject; //СПРОСИТЬ
                
                
                if (hitObject.GetComponent<PlayerCharacter>()) // Игрок распознается тем же способом, что и мишень в сценарии RayShooter
                {
                    if (_fireball == null) // Та же самая логика с пустым игровым объектом, что и в сценарии SceneController
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject; // метод Instatiate работает так же, как и в сценарии SceneController
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f); // Помещаем огненный шар перед врагом и нацелим в направлении его движения
                        //СПРОСИТЬ
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }


                if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0); // поворот с наполовину случайным выбором направления
                }
            }
        }
        
    }
    public void SetAlive (bool alive) // Открытый метод, позволяющий внешнему коду воздействовать на "живое" состояние
    {
        _alive = alive;
    }
    
}

