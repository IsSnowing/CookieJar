using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {

    ///public static GameController GameControl = new GameController();
    public static int HighestScore;
    public static string BallMaterial;
    public static string BorderMaterials;
    public static int Coins;
    public static string BallLock;
    public static string BorderLock;

    //public GameController(){
    //    HighestScore = 0;
    //    BallMaterial = null;
    //    BorderMaterials = null;
    //}

	// Use this for initialization
	void Awake () {
        //if (gameObject == null)
        //{
        //    DontDestroyOnLoad(gameObject);
        //}
        //else if(gameObject != this)
        //{
        //    Destroy(gameObject);
        //}
        //File.Delete(Application.persistentDataPath + "/playerInfo.dat");
        //UnityEditor.AssetDatabase.Refresh();

        if (!File.Exists(Application.persistentDataPath + "/playerInfo.dat"))

        {
            HighestScore = 0;
            BallMaterial = "Ball";
            BorderMaterials = "White";
            Coins = 0;
            BallLock = "111111111111111111111";
            BorderLock = "111111111111111111111";
            Save();
        }
        else
        {
            Skins.loadSkin();
            Skins.loadSkinBall();
        }
            

    }


    public static void addCoin()
    {
        Coins++;
        Debug.Log(Coins);
    }

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.HighestScore = HighestScore;
        data.BallMaterial = BallMaterial;
        data.BorderMaterials = BorderMaterials;
        data.Coins = Coins;
        data.BallLock = BallLock;
        data.BorderLock = BorderLock;

        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            HighestScore = data.HighestScore;
            BallMaterial = data.BallMaterial;
            BorderMaterials = data.BorderMaterials;
            Coins = data.Coins;
            BallLock = data.BallLock;
            BorderLock = data.BorderLock;
        }
    }

    [Serializable]
    class PlayerData
    {
        public int Coins;
        public int HighestScore;
        public string BallMaterial;
        public string BorderMaterials;
        public string BallLock;
        public string BorderLock;
    }
	
}
