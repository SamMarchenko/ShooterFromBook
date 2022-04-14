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
    [SerializeField] private GameObject _camera;
    public GameObject Camera => _camera;
    private FPSInput _fpsInput;
    private MouseLook _mouseLook;

    private void Awake()
    {
        _fpsInput = new FPSInput(this);
        _mouseLook = new MouseLook(this);
    }

    public override void OnTick()
    {
        _fpsInput.PlayerMove();
        _mouseLook.OverviewPlayerEyes();
    }
}

