using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New player", menuName = "Player", order = 53)]
public class PlayerData : ScriptableObject
{
    [Header("Max health")]
    public int PlayerStartHp;
    [Header("Move speed")]
    public float PlayerStartSpeed;
    public float PlayerStartGravity { get; } = -9.8f;
}
