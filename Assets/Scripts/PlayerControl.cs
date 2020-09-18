using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public GameObject player;

	private Vector3 firstTouchPos;
	private Vector3 lastTouchPos;

	private float speed = 3.000f;

    void Start()
    {
        
    }

    void Update() {
    	bool touching = false;
    	if (Input.GetMouseButtonDown(0)) {
    		firstTouchPos = Input.mousePosition;
    		firstTouchPos = Camera.main.ScreenToWorldPoint(firstTouchPos);
    	}
    	else if (Input.GetMouseButton(0)) {
    		lastTouchPos = Input.mousePosition;
    		lastTouchPos = Camera.main.ScreenToWorldPoint(lastTouchPos);
    	}
    	else if (Input.GetMouseButtonUp(0)) {
    		firstTouchPos = new Vector3();
    		lastTouchPos = new Vector3();
    	}
    	if (Input.touchCount > 0) {
    		Touch touch = Input.GetTouch(0);
    		switch (touch.phase) {
    			case TouchPhase.Began:
    				firstTouchPos = touch.position;
    				firstTouchPos = Camera.main.ScreenToWorldPoint(firstTouchPos);
    				break;
    			case TouchPhase.Moved:
    				lastTouchPos = touch.position;
    				lastTouchPos = Camera.main.ScreenToWorldPoint(lastTouchPos);
    				touching = true;
    				break;
    			case TouchPhase.Ended:
    				firstTouchPos = new Vector3();
    				lastTouchPos = new Vector3();
    				break;
    		}
    	}
    	Vector3 touchVector = new Vector3(0, 0, 0);

    	if (lastTouchPos.x != 0 && firstTouchPos.x != 0 && lastTouchPos.y != 0 && firstTouchPos.y != 0) {
    		touchVector = lastTouchPos - firstTouchPos;
    	}

    	float movementAmount = Mathf.Abs(touchVector.x * speed * Time.deltaTime);

    	float newPositionX = player.transform.position.x + touchVector.x * speed * Time.deltaTime;
    	float newPositionY = player.transform.position.y + touchVector.y * speed * Time.deltaTime;

    	if (newPositionX < -3) {
    		newPositionX = -3f;
    		movementAmount = 0;
    	}
    	else if (newPositionX > 3) {
    		newPositionX = 3f;
    		movementAmount = 0;
    	}
    	if (newPositionY < 0) {
    		newPositionY = 0.0f;
    		movementAmount = 0;
    	}
    	else if (newPositionY > 11.0) {
    		newPositionY = 10.0f;
    		movementAmount = 0;
    	}

    	float rotationAmount = 0.0f;
    	rotationAmount = (movementAmount / 0.25f) * 30.0f;

    	if (touchVector.x < 0 && movementAmount > 0.02) {
    		player.transform.rotation = Quaternion.Euler(0, rotationAmount, 0);
    	}
    	else if (touchVector.x > 0 && movementAmount > 0.02) {
    		player.transform.rotation = Quaternion.Euler(0, -rotationAmount, 0);
    	}
    	else {
    		player.transform.rotation = Quaternion.Euler(0, 0, 0);
    	}


    	player.transform.position = new Vector3(newPositionX, newPositionY, player.transform.position.z);
    }
}
