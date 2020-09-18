using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public GameObject playerBarrage;
	private GameObject playerGameObject;

	private float nextFire = 0.0f;
	private float fireRate = 0.16f;

    void Start()
    {
        playerGameObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
    	if ((Input.GetMouseButton(0) || Input.touchCount > 0) && Time.time > nextFire){
    		nextFire = Time.time + fireRate;
    		Vector3 instPos = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0);
    		instPos = new Vector3 (playerGameObject.transform.position.x, playerGameObject.transform.position.y, 0);
    		Instantiate (playerBarrage, instPos, Quaternion.Euler(0, 0, 0));
    	}
        //Instantiate (object, position, rotation);
    }
}
