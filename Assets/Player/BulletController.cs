using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	private float speed = 15.0f;
	public float damage = 10.0f;
	public string type = "Bullet";

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 15) {
        	Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            Destroy(gameObject);
        }
    }
}
