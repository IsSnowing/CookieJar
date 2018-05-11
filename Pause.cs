using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public static int border_pause;
    public static int dot_pause;

   

	// Use this for initialization
	static void Start () {
        border_pause = 0;
        dot_pause = 0;
	}
	
	// Update is called once per frame
	static void Update () {
		
	}
    public static void Border_p(int i)
    {
        border_pause = i;
    }
}
