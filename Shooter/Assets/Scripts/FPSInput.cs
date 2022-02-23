using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] //CПРОСИТЬ
[AddComponentMenu("Control Script/FPS Input")]  //СПРОСИТЬ

public class FPSInput : MonoBehaviour
{
    public float speed = 3f;
    private float deltaX;
    private float deltaZ;

    private CharacterController characterController;

    public float gravity = -9.8f;



    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>(); // Доступ к другим компонентам, присоединенным к этому же объекту
    }

    // Update is called once per frame
    void Update()
    {
        deltaX = Input.GetAxis("Horizontal") * speed;
        deltaZ = Input.GetAxis("Vertical") * speed;
        transform.Translate(deltaX * Time.deltaTime, 0,deltaZ * Time.deltaTime );

        
        //СПРОСИТЬ
        
        Vector3 movement = new Vector3(deltaX, 0 , deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed); // Ограничение движения по диагонали той же скоростью, что и движение параллельно осям
        movement.y = gravity; // Используем значение переменной gravity вместо нуля
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement); //Преобразуем вектор движения от локальных к глобальным координатам
        characterController.Move(movement); //  Заставим этот вектор перемещать компонент CharacterControler
        



    }
}
