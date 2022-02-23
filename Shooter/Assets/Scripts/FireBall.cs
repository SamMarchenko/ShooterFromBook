using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public float speed = 20.0f;

    public int damage = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)  // эта функция вызывается, когда с триггером сталкивается другой объект
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player !=null) //Проверяем, является ли другой обхект объектом PlayerCharacter
        {
            Debug.Log("Player hit");
            player.Hurt(1);
        }
        Destroy(this.gameObject);
    }
}
