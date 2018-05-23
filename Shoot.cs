using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    //public GameObject cannon;
    public GameObject bullet;
    public GameObject itself;
    public float seconds;
    public string direction;
    // Use this for initialization
    void Start () {
        StartCoroutine(createBullet());
		
	}
	
	// Update is called once per frame
	void Update () {
        
        
    }

    IEnumerator createBullet()
    {
        while (true)
        {
            if (direction == "L")
            {
                Vector3 vector = new Vector3(transform.position.x - .3f, transform.position.y, transform.position.z);
                GameObject b = Instantiate(bullet, vector, Quaternion.identity);
                b.GetComponent<Bullet>().direction = "H";
                b.GetComponent<Bullet>().distance = -30;
                b.transform.parent = transform;
                yield return new WaitForSeconds(seconds);
            }else if(direction == "R")
            {
                Vector3 vector = new Vector3(transform.position.x + .3f, transform.position.y, transform.position.z);
                GameObject b = Instantiate(bullet, vector, Quaternion.identity);
                b.GetComponent<Bullet>().direction = "H";
                b.GetComponent<Bullet>().distance = 30;
                b.transform.parent = transform;
                yield return new WaitForSeconds(seconds);
            }
            else if (direction == "D")
            {
                Vector3 vector = new Vector3(transform.position.x, transform.position.y - .3f, transform.position.z);
                GameObject b = Instantiate(bullet, vector, Quaternion.identity);
                b.GetComponent<Bullet>().direction = "V";
                b.GetComponent<Bullet>().distance = -30;
                b.transform.parent = transform;
                yield return new WaitForSeconds(seconds);
            }
            else if (direction == "U")
            {
                Vector3 vector = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);
                GameObject b = Instantiate(bullet, vector, Quaternion.identity);
                b.GetComponent<Bullet>().direction = "V";
                b.GetComponent<Bullet>().distance = 30;
                b.transform.parent = transform;
                yield return new WaitForSeconds(seconds);
            }
        }
    }

}
