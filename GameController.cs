using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {

    public static GameController GameControl = new GameController();
    public int HighestScore;
    public Sprite BallMaterial;
    public Sprite[] BorderMaterials;

    public GameController(){
        HighestScore = 0;
        BallMaterial = null;
        BorderMaterials = null;
    }

	// Use this for initialization
	void Awake () {
        if (GameControl == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else if(GameControl != this)
        {
            Destroy(gameObject);
        }
	}

    public void Save()
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

    public void Load()
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
        public Sprite BallMaterial;
        public Sprite[] BorderMaterials;
    }
	
}
