using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController GameControl;
    public int HighestScore;
    public int BallMaterial;
    public int BorderMaterial;

	// Use this for initialization
	void Awake () {
        if (GameControl == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else if(GameControl != this)
        {
            Destroy(gameObject);
        }
	}
	
}
