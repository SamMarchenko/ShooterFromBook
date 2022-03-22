using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private Weapon weaponData;
    private float _weaponStartAttackSpeed;
    private float _weaponCurrentAttackSpeed;
    private int _weaponStartDamage;

    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    private void Start()
    {
        _weaponStartAttackSpeed = this.weaponData.AttackSpeed;
        _weaponCurrentAttackSpeed = _weaponStartAttackSpeed;
        _weaponStartDamage = this.weaponData.Damage;
        transform.localScale = new Vector3(this.weaponData.Scale, this.weaponData.Scale, this.weaponData.Scale );
    }

    void Update()
    {
        transform.Translate(0,0, _weaponCurrentAttackSpeed * Time.deltaTime);
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
        Destroy(this.gameObject);
    }
    
    private void OnSpeedChanged(float value)
    {
        _weaponCurrentAttackSpeed = _weaponStartAttackSpeed * value;
    }
}
