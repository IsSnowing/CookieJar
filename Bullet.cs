using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public float distance;
    public string direction;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bulletMove();

    }

    void bulletMove()
    {
        //yield return new WaitForSeconds(.5f);
        if (direction == "H")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(distance, transform.position.y, transform.position.z), step);
        }
        else if (direction == "V")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, distance, transform.position.z), step);
        }
    }

 

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Cannon" ||
            col.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
