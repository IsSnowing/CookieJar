using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCannon : MonoBehaviour {

    public List<GameObject> bulletList;
    public string[] StartFromRight = {"R", "U", "L", "D"};
    public string[] StartFromLeft = { "L", "D", "R", "U"};
    public string[] StartFromUp = {"U", "L", "D", "R"};
    public string[] StartFromDown = { "D", "R", "U", "L"};
    public string[] cannonType;
    public GameObject border;


    // Use this for initialization
    void Start () {
        setStartFromList();
    }
	
	// Update is called once per frame
	void Update () {
        changeBulletDirection();

    }


    public void addToBulletList(GameObject b)
    {
        bulletList.Add(b);
    }


    void setStartFromList()
    {
        if ((int)this.transform.rotation.eulerAngles.z == 0 &&
            gameObject.GetComponent<Shoot>().direction == "R")
        {
            cannonType = StartFromRight;

        }
        else if((int)this.transform.rotation.eulerAngles.z == 0 &&
            gameObject.GetComponent<Shoot>().direction == "U")
        {
            cannonType = StartFromUp;
        }
        else if((int)this.transform.rotation.eulerAngles.z == 0 &&
           gameObject.GetComponent<Shoot>().direction == "D")
        {
            cannonType = StartFromDown;
        }
        else if ((int)this.transform.rotation.eulerAngles.z == 0 &&
           gameObject.GetComponent<Shoot>().direction == "L")
        {
            cannonType = StartFromLeft;
        }
    }

    void changeBulletDirection()
    {
        Debug.Log(border.transform.rotation.eulerAngles.z);
        if ((int)border.transform.rotation.eulerAngles.z > -1 &&
            (int)border.transform.rotation.eulerAngles.z < 1)
        {
            changeBulletHelper(cannonType[0]);
        }
        else if ((int)border.transform.rotation.eulerAngles.z > 89 &&
            (int)border.transform.rotation.eulerAngles.z < 91)
        {
            changeBulletHelper(cannonType[1]);
        }
        else if ((int)border.transform.rotation.eulerAngles.z > 179 &&
            (int)border.transform.rotation.eulerAngles.z <181)
        {
            changeBulletHelper(cannonType[2]);
        }
        else if ((int)border.transform.rotation.eulerAngles.z > 269 &&
            (int)border.transform.rotation.eulerAngles.z <271)
        {
            changeBulletHelper(cannonType[3]);
        }
    }
    void changeBulletHelper(string cannonDir)
    {
        string bulletDir;
        if (cannonDir == "U" || cannonDir == "D")
        {
            bulletDir = "V";
        }
        else
        {
            bulletDir = "H";
        }
        int bullDis;
        if(cannonDir == "L" || cannonDir == "D")
        {
            bullDis = -30;
        }
        else
        {
            bullDis = 30;
        }
        gameObject.GetComponent<Shoot>().direction = cannonDir;
        foreach (Transform child in transform)
        {
            //child is your child transform
            Bullet c = child.GetComponent<Bullet>();
            c.direction = bulletDir;
            c.distance = bullDis;
        }
    }
}
