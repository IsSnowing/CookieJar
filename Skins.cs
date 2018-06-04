using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skins : MonoBehaviour {

    public Sprite[] Gold;
    public Sprite[] Green;
    public Sprite[] Grey;
    public Sprite[] LightBlue;
    public Sprite[] Purple;
    public Sprite[] Red;
    public Sprite[] Hollow_Gold;
    public Sprite[] Hollow_Green;
    public Sprite[] Hollow_Grey;
    public Sprite[] Hollow_LightBlue;
    public Sprite[] Hollow_Purple;
    public Sprite[] Hollow_Red;
    public  Sprite[] Zebra_Red;
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
        if (str == "Gold")
        {
            Control.BorderMaterials = Gold;
        }
        else if (str == "Green")
        {
            Control.BorderMaterials = Green;
        }
        else if (str == "Grey")
        {
            Control.BorderMaterials = Grey;
        }
        else if (str == "LightBlue")
        {
            Control.BorderMaterials = LightBlue;
        }
        else if (str == "Purple")
        {
            Control.BorderMaterials = Purple;
        }
        else if (str == "Red")
        {
            Control.BorderMaterials = Red;
        }
        else if (str == "Hollow_Gold")
        {
            Control.BorderMaterials = Hollow_Gold;
        }
        else if (str == "Hollow_Green")
        {
            Control.BorderMaterials = Hollow_Green;
        }
        else if (str == "Hollow_Grey")
        {
            Control.BorderMaterials = Hollow_Grey;
        }
        else if (str == "Hollow_LightBlue")
        {
            Control.BorderMaterials = Hollow_LightBlue;
        }
        else if (str == "Hollow_Purple")
        {
            Control.BorderMaterials = Hollow_Purple;
        }
        else if (str == "Hollow_Red")
        {
            Control.BorderMaterials = Hollow_Red;
        }
        else if (str == "Zebra_Red")
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
