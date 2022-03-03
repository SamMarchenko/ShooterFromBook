using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public int Hp = 2;
    public Material[] mat = new Material[3];

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = mat[2];
    }
    public void ReactToHit()
    {
        var behavior = GetComponent<WanderingAI>();
        if (behavior !=null && Hp ==2)
        {
            gameObject.GetComponent<MeshRenderer>().material = mat[1];
            Hp--;
        }
        else if (behavior != null)
        {
            behavior.SetAlive(false);
            StartCoroutine(Die());
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
            Destroy(this.gameObject);
        }
    }
}
