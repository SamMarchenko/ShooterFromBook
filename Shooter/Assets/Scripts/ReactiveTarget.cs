using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    //public int Hp = 2;
    public Material[] mat = new Material[3];

    [SerializeField] private Enemy EnemyData;
    private int _enemyMaxHp;
    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = mat[2];
        _enemyMaxHp = EnemyData.EnemyHp;
    }
    public void ReactToHit()
    {
        var behavior = GetComponent<WanderingAI>();
        if (behavior !=null && _enemyMaxHp==EnemyData.EnemyHp)
        {
            gameObject.GetComponent<MeshRenderer>().material = mat[1];
            EnemyData.EnemyHp--;
        }
        else if (behavior != null)
        {
            EnemyData.EnemyHp--;
            if (EnemyData.EnemyHp <=0)
            {
                EnemyData.Alive = false;
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
            EnemyData.EnemyHp = _enemyMaxHp;
            EnemyData.Alive = true;
            Destroy(this.gameObject);
        }
    }
}
