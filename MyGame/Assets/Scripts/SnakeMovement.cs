using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;

    public List<GameObject> tailObjects = new List<GameObject>();

    public float ZOffSet = 0.5f;

    public GameObject TailPrefab;

    public Text ScoreText;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        tailObjects.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();

        transform.Translate(Vector3.forward*Speed*Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * RotationSpeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * RotationSpeed * Time.deltaTime);
        }
    }

   public void AddTail()
    {
        score++;

        Vector3 newTailPosition = tailObjects[tailObjects.Count-1].transform.position;

        newTailPosition.z -= ZOffSet;

        tailObjects.Add(GameObject.Instantiate(TailPrefab, newTailPosition, Quaternion.identity) as GameObject);
    }
}
