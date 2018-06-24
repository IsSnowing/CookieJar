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
        if (MoveUp.cameraDis - 10 >= transform.position.y - 5 )//  &&
            //MoveUp.cameraDis < transform.position.y + 13)
        {
            GetComponent<Rotation>().enabled = true;
            if (MoveUp.cameraDis - 10 >= transform.position.y - 5    && tag != "Border1" && create == false)
            {
                Debug.Log("camera distance: " + MoveUp.cameraDis + " position y: " + (transform.position.y) + " create lock: " + (transform.position.y - 4.75f));
            
                GameObject i = Instantiate(Backlock, new Vector3(0, transform.position.y-4.75f, transform.position.z), Quaternion.identity);
                i.transform.parent = transform;
                create = true;
                Score.currentScore++;
            }
        }
        else
        {
            GetComponent<Rotation>().enabled = false; 
        }

        if(MoveUp.cameraDis - 10 > transform.position.y + 15)
        {
            Destroy(gameObject);
        }
    }
}
