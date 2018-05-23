using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{


    GameObject itself;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag != "Cannon")
        Destroy(itself);
    }
}
