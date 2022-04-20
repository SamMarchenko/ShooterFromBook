using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter
{
    private readonly Camera _camera;
    private readonly PlayerView _playerView;

    public RayShooter(PlayerView playerView)
    {
        _playerView = playerView;
        _camera = _playerView.MainCamera.GetComponent<Camera>();
    }

    public void PlayerSoot()
    {
        // Реакция на нажатие кнопки мыши.
        if (Input.GetMouseButtonDown(0) //&&!EventSystem.current.IsPointerOverGameObject()
        )
        {
            // Середина экрана - половина высоты и ширины
            var point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            // Создание в этой точке луча методом ScreenPointToRay().
            var ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;

            // Испущенный луч заполняет информацией переменную, на которую имеется ссылка.
            if (Physics.Raycast(ray, out hit))
            {
                // Получаем объект, в который попал луч.
                var hitObject = hit.transform.gameObject;
                var target = hitObject.GetComponent<ReactiveTarget>();
                //todo: Проверить на жизнеспособность врага
                if (target != null)
                {
                    // Вызов метода для мишени.
                    target.ReactToHit();
                }
            }
        }
    }

    //Сопрограммы пользуются функциями IEnumerator.
    // private IEnumerator SphereIndicator (Vector3 pos)
    // {
    //     var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //     sphere.transform.position = pos;
    //     yield return new WaitForSeconds(1);
    //     Destroy(sphere);
    // }
}