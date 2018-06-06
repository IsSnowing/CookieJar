using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBoderScene : MonoBehaviour {

    private int[] queue = new int[4] { -1, -1, -1, -1 };

    Dictionary<int, bool> borderMap = new Dictionary<int, bool>()
    {
        { 0, false },
        { 1, false },
        { 2, false },
        { 3, false },
    };

    private Scene[] sceneList = new Scene[4];
	// Use this for initialization
	void Start () {
        //load the first 2 scene
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        //queue[1] = 0;
        //SceneManager.UnloadSceneAsync(0);

        int sceneNum = Random.Range(1, 4);
        borderMap[sceneNum] = true;
        SceneManager.LoadScene(sceneNum, LoadSceneMode.Additive);
        //queue[2] = sceneNum;

        //Scene s = SceneManager.GetSceneAt(0);
        //SceneManager.LoadScene(sceneNum, LoadSceneMode.Additive);

    }
	
	// Update is called once per frame
	void Update () {
        
		if(transform.position.y <= -10)
        {
            //while (true)
            //{
            //   int sceneNum = Random.Range(1, 4);
            //   if (borderMap[sceneNum] == false)
            //   {
            //unload scene
            //      unload();
            //      SceneManager.UnloadSceneAsync(sceneNum);

            //add scene
            //      borderMap[sceneNum] = true;
            //      SceneManager.LoadScene(sceneNum, LoadSceneMode.Additive);
            //      queue[queue.Length - 1] = sceneNum;

            //set the condition back
            //      transform.position = new Vector3(0, 0, transform.position.z);
            //      break;
            //  }
            //}

            //add scene
            //borderMap[sceneNum] = true;
            int sceneNum = Random.Range(1, 4);
            SceneManager.LoadScene(sceneNum, LoadSceneMode.Additive);
            queue[queue.Length - 1] = sceneNum;

            //set the condition back
            transform.position = new Vector3(0, 0, transform.position.z);
        } 
	}


    void unload()
    {
        //unload if not empty
        if(queue[0] != -1)
        {
            SceneManager.UnloadSceneAsync(queue[0]);
            borderMap[queue[0]] = false;
        }

        //shift left
        for(int i = 0; i < queue.Length-1; i++)
        {
            queue[i] = queue[i + 1];
        }

       
        //queue[queue.Length - 1] = -1;

    }
}
