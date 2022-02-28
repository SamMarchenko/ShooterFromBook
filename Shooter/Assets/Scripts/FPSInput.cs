using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))] //CПРОСИТЬ
[AddComponentMenu("Control Script/FPS Input")]  //СПРОСИТЬ

public class FPSInput : MonoBehaviour
{
    public float Speed = 3f;
    public float Gravity = -9.8f;
    
    private float _deltaX;
    private float _deltaZ;
    private CharacterController _characterController;
    
    void Start()
    {
        // Доступ к другим компонентам, присоединенным к этому же объекту.
        _characterController = GetComponent<CharacterController>(); 
    }
    
    void Update()
    {
        _deltaX = Input.GetAxis("Horizontal") * Speed;
        _deltaZ = Input.GetAxis("Vertical") * Speed;
        transform.Translate(_deltaX * Time.deltaTime, 0,_deltaZ * Time.deltaTime );
        
        Vector3 movement = new Vector3(_deltaX, 0 , _deltaZ);
        // Ограничение движения по диагонали той же скоростью, что и движение параллельно осям.
        movement = Vector3.ClampMagnitude(movement, Speed); 
        // Используем значение переменной gravity вместо нуля.
        movement.y = Gravity;
        movement *= Time.deltaTime;
        // Преобразуем вектор движения от локальных к глобальным координатам.
        movement = transform.TransformDirection(movement);
        // Заставим этот вектор перемещать компонент CharacterControler.
        _characterController.Move(movement);
    }
}
