using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(GameController.Coins);
        gameObject.GetComponent<Text>().text = "X " + GameController.Coins.ToString();
	}
}
