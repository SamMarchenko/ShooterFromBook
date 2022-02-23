using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>(); // Доступ к другим компонентам, присоединенным к этому же объекту

        Cursor.lockState = CursorLockMode.Locked; // Скрываем указатель мыши в центре экрана
        Cursor.visible = false;                   //
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Реакция на нажатие кнопки мыши
        {
            Vector3 point = new Vector3(camera.pixelWidth/2, camera.pixelHeight/2, 0); // Середина экрана - половина высоты и ширины
            Ray ray = camera.ScreenPointToRay(point);// Создание в этой точке луча методом ScreenPointToRay()
            RaycastHit hit; //СПРОСИТЬ


            if (Physics.Raycast(ray, out hit)) // Испущенный луч заполняет информацией переменную, на которую имеется ссылка
            {
                //Debug.Log("Hit" + hit.point);// Загружаем координаты точки, в которую попал луч
                GameObject hitObject = hit.transform.gameObject; //получаем объект, в который попал луч
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit(); //вызов метода для мишени
          
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point)); // запускаетя сопрограмма для создания сферы в точке попадания
                }
            }
        }
    }

    private IEnumerator SphereIndicator (Vector3 pos) // Сопрограммы пользуются функциями IEnumerator
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);

    }

    void OnGUI()
    {
        int size = 12;
        float posX = camera.pixelWidth / 2 - size/4;
        float posY = camera.pixelHeight / 2 - size/2;
        GUI.Label(new Rect (posX, posY, size, size), "*"); //Команда GUI.Label() отображает на экране символ
    }
}
