using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMasterController : MonoBehaviour
{
	private GameObject playerMaster;
	private float speed = 3.000f;

	private Vector3 firstTouch;
	private Vector3 lastTouch;

    void Start()
    {
    	playerMaster = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
        	firstTouch = Input.mousePosition;
        	firstTouch = Camera.main.ScreenToWorldPoint(firstTouch);
        }
        else if (Input.GetMouseButton(0)) {
        	lastTouch = Input.mousePosition;
        	lastTouch = Camera.main.ScreenToWorldPoint(lastTouch);
        }
        else if (Input.GetMouseButtonUp(0)) {
        	firstTouch = new Vector3();
        	lastTouch = new Vector3();
        }

        if (Input.touchCount > 0) {
        	Touch touch = Input.GetTouch(0);
        	switch(touch.phase) {
        		case TouchPhase.Began:
        			firstTouch = touch.position;
        			firstTouch = Camera.main.ScreenToWorldPoint(firstTouch);
        			break;
        		case TouchPhase.Moved:
        			lastTouch = touch.position;
        			lastTouch = Camera.main.ScreenToWorldPoint(lastTouch);
        			break;
        		case TouchPhase.Ended:
        			firstTouch = new Vector3();
        			lastTouch = new Vector3();
        			break;
        	}
        }

        Vector3 touchVector = new Vector3(0, 0, 0);

        if (lastTouch.x != 0 && firstTouch.x != 0 && lastTouch.y != 0 && firstTouch.y != 0) {
        	touchVector = lastTouch - firstTouch;
        }

        Vector3 touchVectorNormalized = Vector3.Normalize(touchVector);

        //float newPosX = playerMaster.transform.position.x + touchVector.x * speed * Time.deltaTime;
        //float newPosY = playerMaster.transform.position.y + touchVector.y * speed * Time.deltaTime;
        float newPosX = playerMaster.transform.position.x + touchVectorNormalized.x * speed * Time.deltaTime;
        float newPosY = playerMaster.transform.position.y + touchVectorNormalized.y * speed * Time.deltaTime;

        if (newPosX < -2.75) {
        	newPosX = -2.75f;
        }
        else if (newPosX > 2.75) {
        	newPosX = 2.75f;
        }
        if (newPosY < 0) {
        	newPosY = 0.0f;
        }
        else if (newPosY > 10.0) {
        	newPosY = 10.0f;
        }

        float movementAmount = Mathf.Abs(touchVectorNormalized.x * speed * Time.deltaTime);

        float rotation = 0.0f;
        float rotationAmount = (movementAmount / 0.25f) * 50.0f;
        GameObject playerShip = gameObject.transform.GetChild(0).gameObject;

        if (touchVectorNormalized.x < 0 && movementAmount > 0.02) {
        	playerShip.transform.rotation = Quaternion.Euler(-90, rotationAmount, 0);
        }
        else if (touchVectorNormalized.x > 0 && movementAmount > 0.02) {
        	playerShip.transform.rotation = Quaternion.Euler(-90, -rotationAmount, 0);
        }
        else {
        	playerShip.transform.rotation = Quaternion.Euler(-90, 0, 0);
        }

        playerMaster.transform.position = new Vector3(newPosX, newPosY, playerMaster.transform.position.z);
    }
}
