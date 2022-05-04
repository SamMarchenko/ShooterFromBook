using System.Collections;
using System.Collections.Generic;
using Enemies.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : IInitializable, ITickable
{   
    private PlayerView _playerView;
    private float _deltaX;
    private float _deltaZ;
    private float _playerStartSpeed;
    private float _playerCurrentSpeed;
    private float _playerCurrentGravity;

    public FPSInput(PlayerView playerView)
    {
        _playerView = playerView;
    }
    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    
    public void PlayerMove()
    {
        _deltaX = Input.GetAxis("Horizontal") * _playerCurrentSpeed;
        _deltaZ = Input.GetAxis("Vertical") * _playerCurrentSpeed;
        _playerView.Transform.Translate(_deltaX * Time.deltaTime, 0,_deltaZ * Time.deltaTime );
        
        var movement = new Vector3(_deltaX, 0 , _deltaZ);
        // Ограничение движения по диагонали той же скоростью, что и движение параллельно осям.
        movement = Vector3.ClampMagnitude(movement, _playerCurrentSpeed);
        movement.y = _playerCurrentGravity;
        movement *= Time.deltaTime;
        // Преобразуем вектор движения от локальных к глобальным координатам.
        movement = _playerView.Transform.TransformDirection(movement);
        // Заставим этот вектор перемещать компонент CharacterControler.
        _playerView.CharacterController.Move(movement);
    }
    private void OnSpeedChanged(float value)
    {
        _playerCurrentSpeed = _playerStartSpeed * value;
    }

    public void Initialize()
    {
        _playerStartSpeed = _playerView.PlayerData.PlayerStartSpeed;
        _playerCurrentSpeed = _playerStartSpeed;
        _playerCurrentGravity = _playerView.PlayerData.PlayerStartGravity;
    }

    public void Tick()
    {
        PlayerMove();
    }
}
