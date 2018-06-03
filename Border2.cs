using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SpriteRenderer>().sprite = GameController.GameControl.BorderMaterials[1];
	}
	
}
