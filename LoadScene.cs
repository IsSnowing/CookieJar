using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public int num;
	// Use this for initialization
	void Start () {
        SceneManager.LoadScene(num, LoadSceneMode.Additive);
    }
}
