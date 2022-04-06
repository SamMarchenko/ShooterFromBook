using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class FireBallBehavior
{
    private WeaponView _weaponView;
    private float _weaponStartAttackSpeed;
    private float _weaponCurrentAttackSpeed;
    private int _weaponStartDamage;

    public FireBallBehavior(WeaponView weaponView)
    {
        _weaponStartAttackSpeed = weaponView.WeaponData.AttackSpeed;
        _weaponCurrentAttackSpeed = _weaponStartAttackSpeed;
        _weaponStartDamage = weaponView.WeaponData.Damage;
        Init();
    }

    private void Init()
    {
        _weaponView.Transform.localScale = new Vector3(_weaponView.WeaponData.Scale, _weaponView.WeaponData.Scale, _weaponView.WeaponData.Scale);
    }
    
    void Move()
    {
        _weaponView.Transform.Translate(0,0, _weaponCurrentAttackSpeed * Time.deltaTime);
    }

    // Эта функция вызывается, когда с триггером сталкивается другой объект.
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerCharacter>();
        // Проверяем, является ли другой обхект объектом PlayerCharacter.
        if (player !=null) 
        {
            player.Hurt(_weaponStartDamage);
        }
        _weaponView.DestroyWeapon();
    }
    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    private void OnSpeedChanged(float value)
    {
        _weaponCurrentAttackSpeed = _weaponStartAttackSpeed * value;
    }
}
