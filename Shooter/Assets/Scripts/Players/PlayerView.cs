using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Transform Transform => transform;

    [SerializeField] private PlayerData _playerData;
    public PlayerData PlayerData => _playerData;
    [SerializeField] private CharacterController _characterController;
    public CharacterController CharacterController => _characterController;
    [SerializeField] private GameObject _camera;
    public GameObject Camera => _camera;
    
}

