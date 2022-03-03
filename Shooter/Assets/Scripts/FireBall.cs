using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float Speed = 20.0f;
    public int Damage = 1;
    
    void Update()
    {
        transform.Translate(0,0, Speed * Time.deltaTime);
    }

    // Эта функция вызывается, когда с триггером сталкивается другой объект.
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerCharacter>();
        // Проверяем, является ли другой обхект объектом PlayerCharacter.
        if (player !=null) 
        {
            Debug.Log("Player hit");
            player.Hurt(1);
        }
        Destroy(this.gameObject);
    }
}
