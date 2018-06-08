using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBorder : MonoBehaviour
{
    public int borderType;
    public static Sprite[] borderMaterial;
    public static Sprite ballMaterial;
    // Use this for initialization
    void Start()
    {
        if (borderMaterial != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = borderMaterial[borderType - 1];
        }
    }

}
