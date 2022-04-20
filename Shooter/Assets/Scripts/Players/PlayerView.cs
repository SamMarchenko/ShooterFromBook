using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoCache
{
    public Transform Transform => transform;

    [SerializeField] private PlayerData _playerData;
    public PlayerData PlayerData => _playerData;
    [SerializeField] private CharacterController _characterController;
    public CharacterController CharacterController => _characterController;
    [SerializeField] private GameObject _mainCamera;
    public GameObject MainCamera => _mainCamera;
    private Camera _camera;
    private FPSInput _fpsInput;
    private MouseLook _mouseLook;
    private RayShooter _rayShooter;

    private void Awake()
    {
        _fpsInput = new FPSInput(this);
        _mouseLook = new MouseLook(this);
        _rayShooter = new RayShooter(this);
        _camera = _mainCamera.GetComponent<Camera>();
    }

    public override void OnTick()
    {
        _fpsInput.PlayerMove();
        _mouseLook.OverviewPlayerEyes();
        _rayShooter.PlayerSoot();
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

