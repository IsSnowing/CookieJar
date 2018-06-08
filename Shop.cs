using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public int index;
    public string str;
    public int amountCoins;
   

    public void Start()
    {
        changeText();
    }

    public void changeText()
    {
        GameController.Load();
        string middle;
        if (tag == "Shop1")
        {
           
            middle = GameController.BorderLock.Substring(index, 1);
        }
        else
        {
            Debug.Log(GameController.BallLock);
            middle = GameController.BallLock.Substring(index, 1);
        }

        if (middle == "0")
        {
            gameObject.GetComponentInChildren<Text>().text = "";
        }
        else
        {
            //Debug.Log("this is text" + gameObject.GetComponentInChildren<Text>().text);
            gameObject.GetComponentInChildren<Text>().text = amountCoins.ToString();
        }
    }


    public void unlockBorder()
    {
        GameController.Load();

        string s = "abcde";
        Debug.Log("example: " + s.Substring(2,1));
        string middle = GameController.BorderLock.Substring(index, 1);
        Debug.Log("this is startindex: " + index + " this is endindex: " + 1 + " this is middle " + middle);
        if (middle == "1")
        {
            //if there is more coins
            if (GameController.Coins >= amountCoins)
            {
                GameController.Coins -= amountCoins;
                string start = GameController.BorderLock.Substring(0, index);
                string end = GameController.BorderLock.Substring(index + 1);
                GameController.BorderLock = start + "0" + end;

                //GameController.Save();
                Skins.saveSkin(str);
            }
        }
        else
        {
            Skins.saveSkin(str);
        }
    }


    public void unlockBall()
    {
        GameController.Load();
        string middle = GameController.BallLock.Substring(index, 1);
        if (middle == "1")
        {
            //if there is more coins
            if (GameController.Coins >= amountCoins)
            {
                GameController.Coins -= amountCoins;
                string start = GameController.BallLock.Substring(0, index);
                string end = GameController.BallLock.Substring(index + 1);
                GameController.BallLock = start + "0" + end;

                //GameController.Save();
                Skins.saveSkinBall(str);
            }
        }
        else
        {
            Skins.saveSkinBall(str);
        }
    }
}
