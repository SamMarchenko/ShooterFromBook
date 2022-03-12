using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenController : MonoBehaviour
{  [SerializeField] private GameObject PlayerObject;
    private PlayerCharacter PlayerHP;
    [SerializeField] private Camera CameraObject;
    private MouseLook observY;

    [SerializeField] private GameObject DeathScreen;
    // Start is called before the first frame update
    void Start()
    {
        observY = CameraObject.GetComponent<MouseLook>();
        observY.enabled = true;

        PlayerHP = PlayerObject.GetComponent<PlayerCharacter>();
        DeathScreen.SetActive(false);
    }
    
    void Update()
    {
        if (PlayerHP.CurrentHP == 0)
        {
            observY.enabled = false;
            DeathScreen.SetActive(true);
        }
    }
}
