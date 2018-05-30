using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour {

    public string type;
    public List<GameObject> Locks = new List<GameObject>();
    //public GameObject itself;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addLock(GameObject l)
    {
        Locks.Add(l);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("in collision");
        if (col.gameObject.tag == "Yellow" ||
            col.gameObject.tag == "Red" ||
            col.gameObject.tag == "Green" ||
            col.gameObject.tag == "Blue" ||
            col.gameObject.tag == "Ball")
        {
            for(int i = 0; i < Locks.Count; i++)
            {
                Destroy(Locks[i]);
            }
            //Debug.Log("is touch");
            Destroy(gameObject);
        }
    }
}
