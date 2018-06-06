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

        

        if (!File.Exists(Application.persistentDataPath + "/playerInfo.dat"))

        {
            HighestScore = 0;
            BallMaterial = "";
            BorderMaterials = "White";
            Save();
        }
        else
        {
            gameObject.GetComponent<Skins>().loadSkin();
        }
            

    }

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.HighestScore = HighestScore;
        data.BallMaterial = BallMaterial;
        data.BorderMaterials = BorderMaterials;

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
        }
    }

    [Serializable]
    class PlayerData
    {
        public int HighestScore;
        public string BallMaterial;
        public string BorderMaterials;
    }
	
}
