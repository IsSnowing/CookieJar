using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMeanu : MonoBehaviour {
    public int scene;

    public void loadScene(int i)
    {
        SceneManager.LoadScene(i);
        
	}
}
