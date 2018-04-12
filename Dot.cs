using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour {

    public int size;

    public Sprite[] sprites;
	// Use this for initialization
	void Start () {
        size = 1;
	}
	
	// Update is called once per frame
	void Update () {
        display_size();

    }


    public void display_size()
    {
        if(this.size >= 10)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[9];
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[this.size - 1];
        }
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
