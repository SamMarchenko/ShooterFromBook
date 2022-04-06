using System;
using Factory_Method.Interfaces;
using UnityEngine;
using Weapons;

namespace FactoryMethod.Factories
{
    public class WeaponFactory : MonoBehaviour, IWeaponsFactory
    {
        [SerializeField] private WeaponView _weaponView;
        
        // private void Start()
        // {
        //     CreateWeapon();
        // }
        public void CreateWeapon()
        {
            var weaponView = Instantiate<WeaponView>(_weaponView);
            var fireBallBehavior = new FireBallBehavior(weaponView);
        }
        
    }
}