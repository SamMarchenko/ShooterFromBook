using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private Weapon weaponData;

    private void Start()
    {
        transform.localScale = new Vector3(this.weaponData.Scale, this.weaponData.Scale, this.weaponData.Scale );
    }

    void Update()
    {
        transform.Translate(0,0, this.weaponData.AttackSpeed * Time.deltaTime);
    }

    // Эта функция вызывается, когда с триггером сталкивается другой объект.
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerCharacter>();
        // Проверяем, является ли другой обхект объектом PlayerCharacter.
        if (player !=null) 
        {
            Debug.Log("Player hit");
            player.Hurt(this.weaponData.Damage);
        }
        Destroy(this.gameObject);
    }
}
