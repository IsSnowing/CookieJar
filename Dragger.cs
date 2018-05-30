using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour {
    public int prevX, prevY;
    private Vector3 screenPoint;
    private Vector3 offset;
    public Vector2 tempPosition;
    // Use this for initialization
    void Start () {
        prevX = (int)this.transform.position.x;
        prevY = (int)this.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        Drag();

    }
    

    void Drag()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("x:" + Input.mousePosition.x + " y:" + Input.mousePosition.y);
            //Vector3 ws = Camera.main.WorldToScreenPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            //Debug.Log("World to screen x:" + ws.x + " y:" + ws.y);
            Vector3 sw = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            //Debug.Log("Screen to world x:" + sw.x + " y:" + sw.y);
            Vector3 newPosition = new Vector3(sw.x, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
