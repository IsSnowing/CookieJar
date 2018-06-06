using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMeanu : MonoBehaviour {

    public void loadScene(string str)
    {
        SceneManager.LoadScene(str);
        
	}
}
