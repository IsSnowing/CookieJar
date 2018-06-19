using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamera : MonoBehaviour {

	// Use this for initialization
	void Start () { 
        gameObject.transform.position = new Vector3(transform.position.x, MoveUp.cameraDis, transform.position.z);
    }
	

}
