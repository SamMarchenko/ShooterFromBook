using System.Collections;
using System.Collections.Generic;
using FactoryMethod;
using UnityEngine;

public interface IEnemiesFactory
{
   IEnemy Create();
}
