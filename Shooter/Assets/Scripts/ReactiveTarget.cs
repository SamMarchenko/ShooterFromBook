using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public int hp = 2;
    //MeshRenderer MeshRenderer; //СПРОСИТЬ ПОЧЕМУ НЕ РАБОТАЕТ
    public Material[] mat = new Material[3];

    private void Start()
    {
        //gameObject.GetComponent<MeshRenderer>().material = MeshRenderer.materials[2];// скин фулового
       gameObject.GetComponent<MeshRenderer>().material = mat[2];
    }
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();

        if (behavior !=null && hp ==2)
        {
            // gameObject.GetComponent<MeshRenderer>().material = MeshRenderer.materials[1]; //скин раненного
            gameObject.GetComponent<MeshRenderer>().material = mat[1];
            hp--;
        }
        else if (behavior != null)
        {
            behavior.SetAlive(false);
            StartCoroutine(Die());
        }
        
    }

    private IEnumerator Die() // опрокиддывает врага, ждет 1,5 сек и уничтожает его
    {
        if (this.transform.rotation.x == 0)
        {
            this.transform.Rotate(-75, 0, 0);
            // gameObject.GetComponent<MeshRenderer>().material = MeshRenderer.materials[0]; // скин мертвого
            gameObject.GetComponent<MeshRenderer>().material = mat[0];
            yield return new WaitForSeconds(1.5f);
            Destroy(this.gameObject); // объект может уничтожить себя сам как любой другой объект
        }
        
    }
        
}
