using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasView : MonoBehaviour
{
   [SerializeField] private Transform _transform;

   public void Attach(IAttachableUi attachable)
   {
      attachable.Attach(_transform);
   }
}