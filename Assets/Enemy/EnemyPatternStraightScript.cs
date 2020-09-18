using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatternStraightScript : MonoBehaviour
{
	private GameObject[] ships = new GameObject[5];
	public GameObject ship;
	public float speed = 3.00f;

	public bool isLeft = true;
	public float modifier = 0.0f;

    void Start()
    {
        float padding = 0.9f;
        for(int i = 0; i < 5; i++) {
        	Vector3 mPos = this.gameObject.transform.position;
        	//ships[i] = (GameObject) Instantiate(ship, new Vector3(mPos.x, mPos.y + padding, mPos.z), Quaternion.Euler(0, 0, 0));
			ships[i] = GameObject.Instantiate(ship, new Vector3(mPos.x, mPos.y + padding, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
        	padding += 0.9f;
        }
        if (isLeft) {
        	modifier = -1.0f;
        }
        else {
        	modifier = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
    	for(int i = 0; i < 5; i++) {
            if (ships[i] != null){
                Vector3 velVec = new Vector3(0, 0, 0);
                if (ships[i].transform.position.y > 7) {
                    velVec = new Vector3(0, -speed, 0);
                }
                else {
                    ships[i].transform.rotation = Quaternion.Euler(0, (35 * modifier), 0);
                    velVec = new Vector3((modifier * -speed), -speed, 0);
                }
                ships[i].GetComponent<Rigidbody>().velocity = velVec;    
            }
    		//ships[i].transform.rotation = Quaternion.LookRotation(ships[i].GetComponent<Rigidbody>().velocity);
    	}
    }
}
