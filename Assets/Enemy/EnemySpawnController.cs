using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject patternLeft;
    public GameObject patternRight;
	private float nextTime = 0.0f;
	public float sendRate = 10.0f;
    private bool leftTurn = true;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime) {
            nextTime = Time.time + sendRate;
            if (leftTurn) {
                Vector3 instPos = this.gameObject.transform.position;
                instPos.x -= 1.5f;
                Instantiate(patternLeft, instPos, Quaternion.Euler(0, 0, 0));
            }
            else {
                Vector3 instPos = this.gameObject.transform.position;
                instPos.x += 1.5f;
                Instantiate(patternRight, instPos, Quaternion.Euler(0, 0, 0));
            }
            leftTurn = !leftTurn;
        }
    }
}
