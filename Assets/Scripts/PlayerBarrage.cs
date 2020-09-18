using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrage : MonoBehaviour
{
	private float speed = 15.0f;
    void Start()
    {
    	Rigidbody rb = GetComponent<Rigidbody>();
    	rb.velocity = new Vector3(0, speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 10){
        	Destroy(gameObject.transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject.transform.parent.gameObject);
    }
}
