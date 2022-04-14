using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MouseLook
{
    
    private PlayerView _playerView;
    
    public float SensivityHor = 9f;
    public float SensivityVert = 5f;
    public float MinVert = -45f;
    public float MaxVert = 45f;
    // Угол поворота по вертикали.
    private float _rotationX = 0;

    public MouseLook(PlayerView playerView)
    {
        _playerView = playerView;
    }
    public void OverviewPlayerEyes()
    {
        MouseXMove();
        MouseYMove();
    }

   private void MouseXMove()
    {
        _playerView.Transform.Rotate(0, Input.GetAxis("Mouse X") * SensivityHor, 0);
    }

   private void MouseYMove()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * SensivityVert;
        // Фиксируем угол поворота по вертикали, согласно диапазона.
        _rotationX = Mathf.Clamp(_rotationX, MinVert, MaxVert);
        // Сохраняем одинаковый угол поворота вокруг оси Y (вращения по Х не будет).
        float _rotationY = _playerView.Camera.transform.localEulerAngles.y;
        // Создаем новый вектор из сохраненных значений поворота.
        _playerView.Camera.transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
    }
}
