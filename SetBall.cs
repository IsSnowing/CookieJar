using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBall : MonoBehaviour
{
    public static Sprite ballMaterial;
    // Use this for initialization
    void Start()
    {
        //Debug.Log("this is in start " + ballMaterial);
        if (ballMaterial != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ballMaterial;
        }
    }

}
