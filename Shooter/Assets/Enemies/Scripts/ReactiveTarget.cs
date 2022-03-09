using System.Collections;
using System.Collections.Generic;
using Enemies.Scripts;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public Material[] mat = new Material[3];
    private int _enemyMaxHp;
    private Enemy _enemyData;
    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = mat[2];
        _enemyData = gameObject.GetComponent<EnemyController>().EnemyData;
        _enemyMaxHp = _enemyData.EnemyHp;
    }
    public void ReactToHit()
    {
        var behavior = GetComponent<WanderingAI>();
        if (behavior !=null && _enemyMaxHp== _enemyData.EnemyHp)
        {
            gameObject.GetComponent<MeshRenderer>().material = mat[1];
            _enemyData.EnemyHp--;
        }
        else if (behavior != null)
        {
            _enemyData.EnemyHp--;
            if (_enemyData.EnemyHp <=0)
            {
                _enemyData.Alive = false;
                //behavior.SetAlive(false);
                StartCoroutine(Die());
            }
        }
    }
    // Опрокиддывает врага, ждет 1,5 сек и уничтожает его.
    private IEnumerator Die()
    {
        if (this.transform.rotation.x == 0)
        {
            this.transform.Rotate(-75, 0, 0);
            gameObject.GetComponent<MeshRenderer>().material = mat[0];
            yield return new WaitForSeconds(1.5f);
            // Объект может уничтожить себя сам как любой другой объект.
            _enemyData.EnemyHp = _enemyMaxHp;
            _enemyData.Alive = true;
            Destroy(this.gameObject);
        }
    }
}
