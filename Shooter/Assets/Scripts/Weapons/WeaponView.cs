using System.Reflection;
using UnityEngine;

namespace Weapons
{
    public class WeaponView : MonoBehaviour
    {
        public Transform Transform => transform;
        
        [SerializeField] private WeaponData _weaponData;
        public WeaponData WeaponData => _weaponData;
        private FireBallBehavior _fireBallBehavior;

        public void DestroyWeapon()
        {
            Destroy(this.gameObject);
        }
    }
}