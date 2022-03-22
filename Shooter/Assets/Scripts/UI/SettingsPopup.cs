using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
  [SerializeField] private Slider _Slider;

  private void Start()
  {
    _Slider.value = PlayerPrefs.GetFloat("speed", 1);
  }

  public void Open()
  {
    gameObject.SetActive(true);
  }

  public void Close()
  {
    gameObject.SetActive(false);
  }

  public void OnSubmitName(string name)
  {
    Debug.Log(name);
  }

  public void OnSpeedValue(float speed)
  {
    Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    Debug.Log("Speed: " + speed);
    PlayerPrefs.SetFloat("speed", speed);
  }
}
