using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunControl : MonoBehaviour
{
	public GameObject bullet;

	private float nextFire = 0.0f;
	public float fireRate = 0.15f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
    	if ((Input.GetMouseButton(0) || Input.touchCount > 0) && Time.time > nextFire) {
    		nextFire = Time.time + fireRate;
    		Vector3 instPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
    		Instantiate(bullet, instPos, Quaternion.Euler(0, 0, 0));
    	}
    }
}
