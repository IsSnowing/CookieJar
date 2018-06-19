using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public int centerline;

	// Use this for initialization
	void Start () {
        centerline = Screen.width /2;
	}
	
	// Update is called once per frame
	void Update () {
        //StartCoroutine(rotate());
        rotate();

    }
    void rotate()
    {

        if (Input.GetMouseButtonUp(0)  )
        {

            if (Input.mousePosition.x >= centerline)
            {
                StartCoroutine(slowDownRotation(-90));
                //yield return new WaitForSeconds(.5f);
            }
            else if (Input.mousePosition.x < centerline)
            {
                StartCoroutine(slowDownRotation(90));
                //yield return new WaitForSeconds(.5f);
            }
            // Debug.Log("this is rotation" + (int)this.transform.rotation.eulerAngles.z);
            //Debug.Log(allDots[0, 0].tag);
        }

    }
    IEnumerator slowDownRotation(int degree)
    {
        int angle = degree / 5;
        int a = 0;
        while (a < 5)
        {
            this.transform.Rotate(0, 0, angle, Space.World);
            a++;
            yield return new WaitForSeconds(.03f);
        }

    }
}
