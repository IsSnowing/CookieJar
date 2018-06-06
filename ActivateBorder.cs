using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivateBorder : MonoBehaviour {
	// Use this for initialization
	void Start () {
        GetComponent<Rotation>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        activate();

    }

    void activate()
    {
        if (transform.position.y <= -3)
        {
            GetComponent<Rotation>().enabled = true;
            if (transform.position.y <= -12)
            {
                GetComponent<Rotation>().enabled = false; 
            }
        }
        
    }
}
