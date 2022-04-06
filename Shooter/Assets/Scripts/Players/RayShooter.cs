using System.Collections;
using System.Collections.Generic;
using Enemies.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter
{
    //[SerializeField] private Camera _Camera;
    private PlayerView _playerView;
    private GameObject _camera;
    public RayShooter(PlayerView playerView)
    {
        _playerView = playerView;
    }

    private void Init()
    {
        _camera = _playerView.Camera;
    }
    // void Update()
    // {
    //     // Реакция на нажатие кнопки мыши.
    //     if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
    //     {
    //         // Середина экрана - половина высоты и ширины
    //         Vector3 point = new Vector3(_Camera.pixelWidth/2, _Camera.pixelHeight/2, 0);
    //         // Создание в этой точке луча методом ScreenPointToRay().
    //         Ray ray = _playerView.Camera.camera.ScreenPointToRay(point);
    //         RaycastHit hit;
    //         
    //         // Испущенный луч заполняет информацией переменную, на которую имеется ссылка.
    //         if (Physics.Raycast(ray, out hit))
    //         {
    //             // Получаем объект, в который попал луч.
    //             var hitObject = hit.transform.gameObject;
    //             var target = hitObject.GetComponent<ReactiveTarget>();
    //             //todo: Проверить на жизнеспособность врага
    //             if (target != null)
    //             {
    //                 // Вызов метода для мишени.
    //                 target.ReactToHit();
    //             }
    //             else
    //             {
    //                 // Запускаетя сопрограмма для создания сферы в точке попадания.
    //                 StartCoroutine(SphereIndicator(hit.point)); 
    //             }
    //         }
    //     }
    // }
    // // Сопрограммы пользуются функциями IEnumerator.
    // private IEnumerator SphereIndicator (Vector3 pos)
    // {
    //     var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //     sphere.transform.position = pos;
    //     yield return new WaitForSeconds(1);
    //     Destroy(sphere);
    // }
    // void OnGUI()
    // {
    //     int size = 12;
    //     float posX = _Camera.pixelWidth / 2 - size/4;
    //     float posY = _Camera.pixelHeight / 2 - size/2;
    //     // Команда GUI.Label() отображает на экране символ.
    //     GUI.Label(new Rect (posX, posY, size, size), "*"); 
    // }
}
