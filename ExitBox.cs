using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBox : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("in collision");
        if(//col.gameObject.tag == "Ball" ||
            col.gameObject.tag == "Red" ||
            col.gameObject.tag == "Blue" ||
            col.gameObject.tag == "Yellow" ||
            col.gameObject.tag == "Green" )
        {
            //Debug.Log("is touch");
            Debug.Log(gameObject.tag);
            if (gameObject.tag != "Key")
            {
                Destroy(col.gameObject);
            }
        }
    }
}
