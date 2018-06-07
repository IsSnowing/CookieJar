using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivateBorder : MonoBehaviour {
    public GameObject Backlock;
    public bool create = false;
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
            if (tag != "Border1" && create == false)
            {
                GameObject i = Instantiate(Backlock, new Vector3(0, transform.position.y-4.75f, transform.position.z), Quaternion.identity);
                i.transform.parent = transform;
                create = true;
            }
            if (transform.position.y <= -12)
            {
                GetComponent<Rotation>().enabled = false; 
            }
        }
    }
}
