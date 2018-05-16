using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotAnimation : MonoBehaviour {
    Animator anim;
    Dot dot;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        dot = this.GetComponent<Dot>();
    }
	
	// Update is called once per frame
	void Update () {
        changeState();

    }

    void changeState()
    {
        int s = dot.size;
        Debug.Log("this is the dot size");
        Debug.Log(s);
        anim.SetInteger("Dot1", dot.size);
    }
}
