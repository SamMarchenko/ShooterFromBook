using System.Collections;
using System.Collections.Generic;
using Enemies.Scripts;
using UnityEngine;

public class ReactiveTarget
{
    public Material[] mat = new Material[3];
    private int _enemyCurrentHp;
    private EnemyView _enemyView;
    private MeshRenderer _meshRenderer;
    private WanderingAI _wanderingAI;
    
    public ReactiveTarget (EnemyView enemyView, WanderingAI wanderingAi)
    {
        _enemyView = enemyView;
        _wanderingAI = wanderingAi;
        Init();
    }

    private void Init()
    {
        _meshRenderer = _enemyView.MeshRenderer;
        _enemyCurrentHp = _enemyView.Enemy.EnemyMaxHp;
        _meshRenderer.material = _enemyView.Enemy.Materials[2];
    }
    
    
    public void ReactToHit()
    {
        
        if (_wanderingAI !=null && _enemyCurrentHp == _enemyView.Enemy.EnemyMaxHp)
        {
            _meshRenderer.material = mat[1];
            _enemyCurrentHp--;
        }
        else if (_wanderingAI != null)
        {
            _enemyCurrentHp--;
            if (_enemyCurrentHp <=0)
            {
                _enemyView.Enemy.Alive = false;
                Messenger.Broadcast(GameEvent.ENEMY_HIT);
                _enemyView.StartAnimationDie();
            }
        }
    }
    
    
}
