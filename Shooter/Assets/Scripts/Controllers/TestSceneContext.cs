using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using FactoryMethod;
using UnityEngine;

public class TestSceneContext : MonoBehaviour
{
    private TestSceneController testSceneController;

    private IEnemy enemy;
    // Start is called before the first frame update

    // private void Awake()
    // {
    //     Debug.Log("Proverka svyazi v Awake");
    //     testSceneController = new TestSceneController();
    // }
    //
    // void Start()
    // {
    //     Debug.Log("Proverka svyazi v Start");
    //     enemy = testSceneController.NeedEnemy();
    //     enemy.WanderingAI();
    //     enemy.ReactToHit();
    // }
    
}
