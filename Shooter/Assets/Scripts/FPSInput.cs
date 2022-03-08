using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{
    [SerializeField] private Player PlayerData;
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
        _deltaX = Input.GetAxis("Horizontal") * PlayerData.PlayerSpeed;
        _deltaZ = Input.GetAxis("Vertical") * PlayerData.PlayerSpeed;
        transform.Translate(_deltaX * Time.deltaTime, 0,_deltaZ * Time.deltaTime );
        
        var movement = new Vector3(_deltaX, 0 , _deltaZ);
        // Ограничение движения по диагонали той же скоростью, что и движение параллельно осям.
        movement = Vector3.ClampMagnitude(movement, PlayerData.PlayerSpeed); 
        // Используем значение переменной gravity вместо нуля.
        movement.y = PlayerData.Gravity;
        movement *= Time.deltaTime;
        // Преобразуем вектор движения от локальных к глобальным координатам.
        movement = transform.TransformDirection(movement);
        // Заставим этот вектор перемещать компонент CharacterControler.
        _characterController.Move(movement);
    }
    
}
