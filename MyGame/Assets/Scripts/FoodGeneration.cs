using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour
{
    public float XSize = 8.8f;
    public float ZSize = 8.8f;

    public GameObject currentFood;
    public GameObject foodPrefab;
    public Vector3 currentPosition;
    // Start is called before the first frame update
    void AddNewFood()
    {
        RandomPosition();
        currentFood = GameObject.Instantiate(foodPrefab, currentPosition, Quaternion.identity) as GameObject;
    }

    void RandomPosition ()
    {
        currentPosition = new Vector3(Random.Range(-1 * XSize, XSize),0.25f, Random.Range(-1 * ZSize, ZSize));
    }
    private void Update()
    {
        if(!currentFood)
        {
            AddNewFood();
        }
        else
        {
            return;
        }
    }
}
