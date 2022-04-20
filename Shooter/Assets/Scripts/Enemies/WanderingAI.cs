using Enemies.Scripts;
using FactoryMethod.Factories;
using UnityEngine;
using Weapons;

public class WanderingAI
{
    //private GameObject _fireballPrefab; 
    private WeaponView _fireballPrefab;
    private WeaponData[] _weapons;
    private float _enemyStartSpeed;
    private float _enemyCurrentSpeed;
    private float _currentVewingRange;
    private WeaponFactory _weaponFactory;
    
    public WanderingAI (WeaponView fireballPrefab, WeaponData[] weapons, WeaponFactory weaponFactory)
    {
        _fireballPrefab = fireballPrefab;
        _weapons = weapons;
        _weaponFactory = weaponFactory;
        Init();
    }
    private void Init()
    {
        _enemyCurrentSpeed = _enemyStartSpeed;
    }
    
    public void Shoot()
    {
        //if (_fireball == null)
        {
            Debug.Log("Bang Bang");
            _weaponFactory.CreateWeapon();
            //_fireball.transform.position = _enemyView.Transform.TransformPoint(Vector3.forward * 1.5f); 
            //_fireball.transform.rotation = _enemyView.Transform.rotation;
        }
    }
    
}

