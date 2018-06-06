using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skins : MonoBehaviour {
    public Sprite[] White;

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
    public Sprite[] Rainbow;
    public Sprite[] Shine;


    public int borderType;
    private Sprite[] current;

    // Use this for initialization
    void Start()
    {
        loadSkin();
    }

    public void loadSkin()
    {
        GameController.Load();
        Debug.Log(GameController.BorderMaterials);
        if (GameController.BorderMaterials != null)
        {
            
            current = changeBorderSkin(GameController.BorderMaterials);
            SetBorder.borderMaterial = current;
        }
    }

    public void saveSkin(string str)
    {
        GameController.BorderMaterials = str;
        GameController.Save();
        loadSkin();
    }

    private Sprite[] changeBorderSkin(string str)
    {
        //gameObject.GetComponent<GameController>().HighestScore++;
        Debug.Log(str);
        //GameController Control = GameController.GameControl;
        if (str == "Gold")
        {
            return Gold;
        }
        else if (str == "Green")
        {
            return Green;
        }
        else if (str == "Grey")
        {
            return Grey;
        }
        else if (str == "LightBlue")
        {
            return LightBlue;
        }
        else if (str == "Purple")
        {
            return Purple;
        }
        else if (str == "Red")
        {
            return Red;
        }
        else if (str == "Hollow_Gold")
        {
            return Hollow_Gold;
        }
        else if (str == "Hollow_Green")
        {
            return Hollow_Green;
        }
        else if (str == "Hollow_Grey")
        {
            return Hollow_Grey;
        }
        else if (str == "Hollow_LightBlue")
        {
            return Hollow_LightBlue;
        }
        else if (str == "Hollow_Purple")
        {
            return Hollow_Purple;
        }
        else if (str == "Hollow_Red")
        {
            return Hollow_Red;
        }
        else if (str == "Zebra_Red")
        {
            return Zebra_Red;
        }
        //Debug.Log(Control.BorderMaterials);
        else if(str == "Zebra_Blue")
        {
            return Zebra_Blue;
        }
        else if (str == "Zebra_Yellow")
        {
            return Zebra_Yellow;
        }
        else if (str == "Zebra_Green")
        {
            return Zebra_Green;
        }
        else if (str == "Zebra_Pink")
        {
            return Zebra_Pink;
        }
        else if (str == "Zebra_Orange")
        {
            return Zebra_Orange;
        }
        else if (str == "Maple")
        {
            return Maple;
        }
        else if (str == "Rainbow")
        {
            return Rainbow;
        }
        else if (str == "Shine")
        {
            return Shine;
        }
        return White;
        
    }
}
