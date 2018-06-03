using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skins : MonoBehaviour {

    public  Sprite[] Zebra_Red = new Sprite[4];
    public  Sprite[] Zebra_Blue;
    public  Sprite[] Zebra_Yellow;
    public  Sprite[] Zebra_Green;
    public  Sprite[] Zebra_Pink;
    public  Sprite[] Zebra_Orange;
    public  Sprite[] Maple;


    public void changeBorderSkin(string str)
    {
        //gameObject.GetComponent<GameController>().HighestScore++;
        //Debug.Log(Control.BorderMaterials);
        GameController Control = GameController.GameControl;
        if (str == "Zebra_Red")
        {
            Control.BorderMaterials = Zebra_Red;
        }
        //Debug.Log(Control.BorderMaterials);
        else if(str == "Zebra_Blue")
        {
            Control.BorderMaterials = Zebra_Blue;
        }
        else if (str == "Zebra_Yellow")
        {
            Control.BorderMaterials = Zebra_Yellow;
        }
        else if (str == "Zebra_Green")
        {
            Control.BorderMaterials = Zebra_Green;
        }
        else if (str == "Zebra_Pink")
        {
            Control.BorderMaterials = Zebra_Pink;
        }
        else if (str == "Zebra_Orange")
        {
            Control.BorderMaterials = Zebra_Orange;
        }
        else if (str == "Maple")
        {
            Control.BorderMaterials = Maple;
        }
    }
}
