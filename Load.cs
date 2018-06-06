using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Load : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.LoadScene("Border0_1", LoadSceneMode.Additive);
    }
	

}
