using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBoderScene : MonoBehaviour {
    private Scene[] sceneList = new Scene[4];
	// Use this for initialization
	void Start () {
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        int sceneNum = Random.Range(1, 4);
        SceneManager.LoadScene(sceneNum, LoadSceneMode.Additive);
        Scene s = SceneManager.GetSceneAt(0);
        //SceneManager.LoadScene(sceneNum, LoadSceneMode.Additive);

    }
	
	// Update is called once per frame
	void Update () {
        
		if(transform.position.y <= -10)
        {
            int sceneNum = Random.Range(1, 4);
            SceneManager.LoadScene(sceneNum, LoadSceneMode.Additive);
            transform.position = new Vector3(0, 0, transform.position.z);
            
        }

       
	}
}
