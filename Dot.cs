using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour {

    public int size;
    public float newx;
    public float newy;
    public int dataIndexX;
    public int dataIndexY;
    public int pause_game = 0;
    //public static int pause;
    private Vector3 pre_pos;
    private float space_x = 0;
    private float space_y = 0;
    public int distroy;
    


    public Sprite[] sprites;
	// Use this for initialization
	void Start () {
       // newx = this.transform.position.x;
       // newy = this.transform.position.y;
        size = 1;
        distroy = 0;

    }
	
	// Update is called once per frame
	void Update () {
        
        display_size();
        //moveDot();

    }
    //set up the amount space want to move each time
    //if the distance is different from the original
    //total distance [----------]
    //distance for each movement [--]
    public void set_space(int amount)
    {
       //space_x = (newx - this.transform.position.x) / amount;
       space_y = (newy - this.transform.position.y) / amount;
    }

    //move the dot to the new position smoothly
    public int moveDot()
    {
        Debug.Log(this.distroy);
        //board.pause = 1;

        //total distance [----------]
        //[] + [--] ... [--] + [--] ... [----] + [--] until [----------]
        //float subx = this.transform.position.x + space_x;
        float suby = this.transform.position.y + space_y;
        if (suby > newy && Border.rotating == 0)
        {
            pause_game = 1;
            pre_pos = this.transform.position;
            Vector3 new_pos = new Vector3(this.transform.position.x + space_x, this.transform.position.y + space_y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(pre_pos, new_pos, .5f);
            Border.can_move[dataIndexX,dataIndexY] = 1;
            //this.transform.position = new_pos;
            return 1;
        }
        else
        {
            this.transform.position = new Vector3(newx, newy, this.transform.position.z);
            pause_game = 0;
            space_x = 0;
            space_y = 0;
            //Border.pause = 0;
            //Debug.Log((int)newx);
            //Debug.Log((int)newy);
            Border.can_move[dataIndexX, dataIndexY] = 0;
            if (this.distroy == 1)
            {
                Debug.Log("it is destroy");
                Destroy(this);
            }
            return 0;
        }
        
    }

    public IEnumerator activate_moveDot()
    {
        int state = 1;
        while (state == 1)
        {
            state = moveDot();
            yield return new WaitForSeconds(.001f);
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
