using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour {

    public int size;
    public float newx;
    public float newy;
    public int should_move = 0;
    private Vector3 pre_pos;

    public Sprite[] sprites;
	// Use this for initialization
	void Start () {
        newx = this.transform.position.x;
        newy = this.transform.position.y;
        size = 1;
	}
	
	// Update is called once per frame
	void Update () {
        pre_pos = this.transform.position;
        display_size();
        moveDot();

    }

    public void moveDot()
    {
        if (should_move == 1)
        {
            Vector3 new_pos = new Vector3(newx, newy, this.transform.position.z);
            this.transform.position = Vector3.Lerp(pre_pos, new_pos, .4f);
            if (this.transform.position == new_pos)
            {
                should_move = 0;
            }
        }
        
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
