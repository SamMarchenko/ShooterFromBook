using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeLogic : MonoCache
{
    public GameObject prefab;

    public override void OnTick()
    {
        RotateCube();
    }

    private void RotateCube()
    {
        Quaternion rotationY = Quaternion.AngleAxis(1, Vector3.up);
        transform.rotation *= rotationY;
    }
}
