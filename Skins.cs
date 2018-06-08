using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skins : MonoBehaviour {
    
    //Border
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

    //Ball
    public Sprite Ball;

    public Sprite BallYellow;
    public Sprite BallRed;
    public Sprite BallPurple;
    public Sprite BallPink;
    public Sprite BallGreen;
    public Sprite BallBlue;
    public Sprite BallYellow3D;
    public Sprite BallRed3D;
    public Sprite BallPurple3D;
    public Sprite BallPink3D;
    public Sprite BallGreen3D;
    public Sprite BallBlue3D;
    public Sprite SmileBlue;
    public Sprite SmileGreen;
    public Sprite SmilePink;
    public Sprite SmilePurple;
    public Sprite SmileRed;
    public Sprite SmileYellow;
    public Sprite Random;
    public Sprite Square;
    public Sprite Cosmic;


    public int borderType;
    private Sprite[] current;
    private Sprite curretBall;

    // Use this for initialization
    void Start()
    {
        loadSkin();
        loadSkinBall();
    }

    public void loadSkin()
    {
        GameController.Load();
        //Debug.Log(GameController.BorderMaterials);
        if (GameController.BorderMaterials != null)
        {
            
            current = changeBorderSkin(GameController.BorderMaterials);
            SetBorder.borderMaterial = current;
        }
    }

    public void loadSkinBall()
    {
        GameController.Load();
        Debug.Log(GameController.BallMaterial);
        if (GameController.BallMaterial != null)
        {

            curretBall = changeBallSkin(GameController.BallMaterial);
            SetBall.ballMaterial = curretBall;
        }
    }

    public void saveSkin(string str)
    {
        GameController.BorderMaterials = str;
        GameController.Save();
        loadSkin();
    }
    public void saveSkinBall(string str)
    {
        GameController.BallMaterial = str;
        GameController.Save();
        loadSkinBall();
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

    private Sprite changeBallSkin(string str)
    {
        //gameObject.GetComponent<GameController>().HighestScore++;
        Debug.Log(str);
        //GameController Control = GameController.GameControl;
        if (str == "BallYellow")
        {
            return BallYellow;
        }
        else if (str == "BallRed")
        {
            return BallRed;
        }
        else if (str == "BallPurple")
        {
            return BallPurple;
        }
        else if (str == "BallPink")
        {
            return BallPink;
        }
        else if (str == "BallGreen")
        {
            return BallGreen;
        }
        else if (str == "BallBlue")
        {
            return BallBlue;
        }
        else if (str == "BallYellow3D")
        {
            return BallYellow3D;
        }
        else if (str == "BallRed3D")
        {
            return BallRed3D;
        }
        else if (str == "BallPurple3D")
        {
            return BallPurple3D;
        }
        else if (str == "BallPink3D")
        {
            return BallPink3D;
        }
        else if (str == "BallGreen3D")
        {
            return BallGreen3D;
        }
        else if (str == "BallBlue3D")
        {
            return BallBlue3D;
        }
        else if (str == "SmileBlue")
        {
            return SmileBlue;
        }
        //Debug.Log(Control.BorderMaterials);
        else if (str == "SmileGreen")
        {
            return SmileGreen;
        }
        else if (str == "SmilePink")
        {
            return SmilePink;
        }
        else if (str == "SmilePurple")
        {
            return SmilePurple;
        }
        else if (str == "SmileRed")
        {
            return SmileRed;
        }
        else if (str == "SmileYellow")
        {
            return SmileYellow;
        }
        else if (str == "Random")
        {
            return Random;
        }
        else if (str == "Square")
        {
            return Square;
        }
        else if (str == "Cosmic")
        {
            return Cosmic;
        }
        return Ball;

    }
}
