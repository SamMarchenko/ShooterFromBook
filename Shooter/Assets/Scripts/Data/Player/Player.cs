using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New player", menuName = "Player", order = 53)]
public class Player : ScriptableObject
{
    [Header("Max health")]
    public int PlayerHp;
    [Header("Move speed")]
    public float PlayerSpeed;
    public float Gravity { get; } = -9.8f;
}
