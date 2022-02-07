using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaleMovement : MonoBehaviour
{
    public float Speed;

    public Vector3 tailTarget;

    public int index;

    public GameObject tailTargetObj;

    public SnakeMovement mainSnake;

    // Start is called before the first frame update
    void Start()
    {
       
        mainSnake = GameObject.FindGameObjectWithTag("SnakeMain").GetComponent<SnakeMovement>();
        Speed = mainSnake.Speed * 1.5f;
        tailTargetObj = mainSnake.tailObjects[mainSnake.tailObjects.Count - 2];

        index = mainSnake.tailObjects.IndexOf(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        tailTarget = tailTargetObj.transform.position;
     
        transform.LookAt(tailTarget);
        transform.position = Vector3.Lerp(transform.position,tailTarget,Time.deltaTime*Speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeMain"))
        {
            if (index >2)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
