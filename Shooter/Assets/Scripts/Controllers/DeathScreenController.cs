using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenController : MonoBehaviour
{  
    [SerializeField] private GameObject PlayerObject;
    private PlayerCharacter PlayerHP;
    [SerializeField] private Camera CameraObject;
    private MouseLook observY;
    private RayShooter Shoot;
    private Scene currentScene;

    [SerializeField] private GameObject DeathScreen;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        observY = CameraObject.GetComponent<MouseLook>();
        observY.enabled = true;

        Shoot = CameraObject.GetComponent<RayShooter>();
        Shoot.enabled = true;

        PlayerHP = PlayerObject.GetComponent<PlayerCharacter>();
        DeathScreen.SetActive(false);
    }
    
    void Update()
    {
        if (PlayerHP.CurrentHP == 0)
        {
            observY.enabled = false;
            Shoot.enabled = false;
            DeathScreen.SetActive(true);
            if (Input.GetKeyUp(KeyCode.F))
            {
                SceneManager.LoadScene(currentScene.buildIndex, LoadSceneMode.Single);
                Debug.Log("F clicked");
            }
        }
    }
}
