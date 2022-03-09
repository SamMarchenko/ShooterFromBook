using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New enemy", menuName = "Enemy", order = 51)]
public class Enemy : ScriptableObject
{
   [Header("Max health")]
   public int EnemyHp;
   [Header("Move speed")]
   public float EnemySpeed;
   [Header("Viewing range")]
   public float VewingRange;
   
   private bool _alive = true;
   public bool Alive 
   {
      get { return _alive; }
      set { _alive = value; }
   }
}
