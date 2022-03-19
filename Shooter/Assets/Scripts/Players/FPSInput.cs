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
    [SerializeField] private CharacterController _CharacterController;
    private float _playerCurrentSpeed;
    private float _playerCurrentGravity;
    
    void Start()
    {
        _playerCurrentSpeed = PlayerData.PlayerSpeed;
        _playerCurrentGravity = PlayerData.Gravity;
    }
    
    void Update()
    {
        _deltaX = Input.GetAxis("Horizontal") * _playerCurrentSpeed;
        _deltaZ = Input.GetAxis("Vertical") * _playerCurrentSpeed;
        transform.Translate(_deltaX * Time.deltaTime, 0,_deltaZ * Time.deltaTime );
        
        var movement = new Vector3(_deltaX, 0 , _deltaZ);
        // Ограничение движения по диагонали той же скоростью, что и движение параллельно осям.
        movement = Vector3.ClampMagnitude(movement, _playerCurrentSpeed); 
        // Используем значение переменной gravity вместо нуля.
        movement.y = _playerCurrentGravity;
        movement *= Time.deltaTime;
        // Преобразуем вектор движения от локальных к глобальным координатам.
        movement = transform.TransformDirection(movement);
        // Заставим этот вектор перемещать компонент CharacterControler.
        _CharacterController.Move(movement);
    }
    
}
