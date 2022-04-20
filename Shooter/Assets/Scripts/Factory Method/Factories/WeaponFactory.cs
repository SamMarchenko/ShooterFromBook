using System;
using Enemies.Scripts;
using Factory_Method.Interfaces;
using UnityEngine;
using Weapons;

namespace FactoryMethod.Factories
{
    public class WeaponFactory : MonoBehaviour, IWeaponsFactory
    {
        [SerializeField] private WeaponView _weaponView;
        
        public void CreateWeapon()
        {
            var weaponView = Instantiate<WeaponView>(_weaponView);
            var fireBallBehavior = new FireBallBehavior(weaponView);
        }
    }
}