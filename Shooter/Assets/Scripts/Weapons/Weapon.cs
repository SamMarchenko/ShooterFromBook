using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New weapon", menuName = "Weapon", order = 52)]
public class Weapon : ScriptableObject
{
    [Header("Attack speed")]
    public float AttackSpeed;
    [Header("Damage")]
    public int Damage;
    [Header("Radius")] 
    public float Scale;
}
