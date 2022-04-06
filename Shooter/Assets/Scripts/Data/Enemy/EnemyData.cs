using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New enemy", menuName = "Enemy", order = 51)]
public class EnemyData : ScriptableObject
{
   [Header("Max health")]
   public int EnemyMaxHp;
   [Header("Move speed")]
   public float EnemySpeed;
   [Header("Viewing range")]
   public float VewingRange;

   public Material[] Materials;
   
   private bool _alive = true;
   public bool Alive 
   {
      get { return _alive; }
      set { _alive = value; }
   }
}
