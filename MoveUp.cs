using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour {
    public static float cameraDis;
    private static float speed;
    private static float distance;
    // Use this for initialization
    void Start()
    {
        speed = 3.5f;
        distance = 100000000;
        cameraDis = 0;
        //GameCondition.pauseGame = false;
    }
	
	// Update is called once per frame
	void Update () {
        //if (transform.position.y >= distance)
        //{
        cameraDis = transform.position.y;
        Move();
        //}

    }

    private void Move()
    {
        //Debug.Log(speed);
        
        if (GameCondition.pauseGame == false)
        {
            if (speed < 8)
            {
                speed += .001f;
            }
            //float step = speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, distance, transform.position.z), step);
            //distance += 1;
            transform.position += transform.up * Time.deltaTime * speed;
        }
    }
}
