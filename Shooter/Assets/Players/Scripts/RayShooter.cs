using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        // Доступ к другим компонентам, присоединенным к этому же объекту.
        _camera = GetComponent<Camera>();
        // Скрываем указатель мыши в центре экрана.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        // Реакция на нажатие кнопки мыши.
        if (Input.GetMouseButtonDown(0))
        {
            // Середина экрана - половина высоты и ширины
            Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
            // Создание в этой точке луча методом ScreenPointToRay().
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            
            // Испущенный луч заполняет информацией переменную, на которую имеется ссылка.
            if (Physics.Raycast(ray, out hit))
            {
                // Получаем объект, в который попал луч.
                GameObject hitObject = hit.transform.gameObject;
                var target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    // Вызов метода для мишени.
                    target.ReactToHit();
                }
                else
                {
                    // Запускаетя сопрограмма для создания сферы в точке попадания.
                    StartCoroutine(SphereIndicator(hit.point)); 
                }
            }
        }
    }
    // Сопрограммы пользуются функциями IEnumerator.
    private IEnumerator SphereIndicator (Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size/4;
        float posY = _camera.pixelHeight / 2 - size/2;
        // Команда GUI.Label() отображает на экране символ.
        GUI.Label(new Rect (posX, posY, size, size), "*"); 
    }
}
