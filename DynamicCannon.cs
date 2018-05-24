using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCannon : MonoBehaviour {

    public List<GameObject> bulletList;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void addToBulletList(GameObject b)
    {
        bulletList.Add(b);
    }

    void changeBulletDirection()
    {
        if ((int)this.transform.rotation.eulerAngles.z == 0)
        {
            ;
        }
        else if ((int)this.transform.rotation.eulerAngles.z == 270)
        {
            drop_helper();
        }
        else if ((int)this.transform.rotation.eulerAngles.z == 90)
        {
            drop_helper();
        }
        else if ((int)this.transform.rotation.eulerAngles.z == 180)
        {
            drop_helper();
        }
    }
    void changeBulletHelper(string cannonDir, string bulletDir)
    {
        foreach (Transform child in transform)
        {
            //child is your child transform
        }
    }
}
