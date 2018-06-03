using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBorder : MonoBehaviour
{
    public int borderType;
    // Use this for initialization
    void Start()
    {
        if (GameController.GameControl.BorderMaterials != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = GameController.GameControl.BorderMaterials[borderType - 1];
        }
    }

}
