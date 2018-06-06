using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour {
    private float speed;
    private float distance;
    // Use this for initialization
    void Start()
    {
         speed = .5f;
         distance = 1;
        //GameCondition.pauseGame = false;
    }
	
	// Update is called once per frame
	void Update () {
        Move();

    }

    private void Move()
    {
        Debug.Log(speed);
        if (transform.position.y < -7 && GameCondition.pauseGame == false)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, distance, transform.position.z), step);
            distance += 1;
        }
    }
}
