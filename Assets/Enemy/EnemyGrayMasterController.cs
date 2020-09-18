using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrayMasterController : MonoBehaviour
{
    private GameObject enemyGrayMaster;
    float speed = 0.005f;
    public float remainingHealth = 100.0f;

    void Start()
    {
    	enemyGrayMaster = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    	if (remainingHealth < 0) {
    		Destroy(gameObject);
        }
        //enemyGrayMaster.transform.position = new Vector3(enemyGrayMaster.transform.position.x, enemyGrayMaster.transform.position.y - speed, enemyGrayMaster.transform.position.z);
    }

    private void OnTriggerEnter(Collider other) {
    	Debug.Log("Collision!!");
    	BulletController BulletScript = other.gameObject.GetComponent<BulletController>();
    	float damageReceived = 0.0f;
    	if (BulletScript.type == "Bullet"){
    		damageReceived = BulletScript.damage;
    	}
    	remainingHealth -= damageReceived;
    }
}
