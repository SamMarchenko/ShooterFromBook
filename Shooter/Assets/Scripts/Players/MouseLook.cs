using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MouseLook : MonoBehaviour
{
    public enum Rotationaxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public Rotationaxes axes = Rotationaxes.MouseXandY;
    public float SensivityHor = 9f;
    public float SensivityVert = 5f;
    public float MinVert = -45f;
    public float MaxVert = 45f;

    // Угол поворота по вертикали.
    private float _rotationX = 0;
    void Start()
    {
        var body = GetComponent<Rigidbody>();
        // Проверяем, существует ли этот компонент.
        if (body!= null)
        {
            body.freezeRotation = true;
        }
    }
    void Update()
    {
        // Вращение по горизонтали.
        if (axes == Rotationaxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * SensivityHor, 0);
        }

        // Вращение по вертикали.
        else if (axes == Rotationaxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * SensivityVert;
            // Фиксируем угол поворота по вертикали, согласно диапазона.
            _rotationX = Mathf.Clamp(_rotationX, MinVert, MaxVert);
            
            // Сохраняем одинаковый угол поворота вокруг оси Y (вращения по Х не будет).
            float _rotationY = transform.localEulerAngles.y;
            // Создаем новый вектор из сохраненных значений поворота.
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
        // Комбинированное вращение.
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * SensivityVert;
            _rotationX = Mathf.Clamp(_rotationX, MinVert, MaxVert);

            // Приращение угла поворота через  delta.
            float delta = Input.GetAxis("Mouse X") * SensivityHor;
            // delta - величина изменения угла поворота.
            float _rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
    }
}
