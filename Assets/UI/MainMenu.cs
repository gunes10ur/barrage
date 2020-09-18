using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameScene;
    public GameObject redShip;
    public float shipTurnSpeed = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
    		redShip.transform.RotateAround(redShip.transform.position, Vector3.up, 30 * Time.deltaTime);
    }

    public void StartButton() {
    	SceneManager.LoadScene(gameScene);
    }

    public void nextShipButton() {
    }

    public void prevShipButton() {

    }
}
