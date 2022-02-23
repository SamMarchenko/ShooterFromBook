using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum Rotationaxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public Rotationaxes axes = Rotationaxes.MouseXandY;

    public float sensivityHor = 9f;

    public float sensivityVert = 5f;
    public float minVert = -45f;
    public float maxVert = 45f;

    private float _rotationX = 0; // угол поворота по вертикали

    void Start()
    {
        /*
         * СПРОСИТЬ
         */
        Rigidbody body = GetComponent<Rigidbody>();
        if (body!= null) //Проверяем, существует ли этот компонент
        {
            body.freezeRotation = true;
        }
    }

    void Update()
    {
        if (axes == Rotationaxes.MouseX) // Вращение по горизонтали
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensivityHor, 0);
            //float delta = Input.GetAxis("Mouse X") * sensivityHor; // приращение угла поворота через  delta
            //float _rotationY = transform.localEulerAngles.y + delta;
            //float _rotationX = transform.localEulerAngles.x;
            //transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }


        else if (axes == Rotationaxes.MouseY) // Вращение по вертикали
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensivityVert; 

            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert); // фиксируем угол поворота по вертикали, согласно диапазона

            float _rotationY = transform.localEulerAngles.y; // сохраняем одинаковый угол поворота вокруг оси Y (вращения по Х не будет)
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0); // создаем новый вектор из сохраненных значений поворота
        }
        else // Комбинированное вращение
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * sensivityHor; // приращение угла поворота через  delta
            float _rotationY = transform.localEulerAngles.y + delta; // delta - величина изменения угла поворота
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
    }
}
