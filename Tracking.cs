using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour {

    public float speed;
    public Vector3 location;
    public GameObject ball;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();

    }

    void move()
    {
        //yield return new WaitForSeconds(.5f);
        if (ball != null)
        {
            location = ball.gameObject.transform.position;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, location, step);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("in collision");
        if (col.gameObject.tag == "Ball" ||
            col.gameObject.tag == "Red" ||
            col.gameObject.tag == "Blue" ||
            col.gameObject.tag == "Yellow" ||
            col.gameObject.tag == "Green")
        {
            //Debug.Log("is touch");
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}


