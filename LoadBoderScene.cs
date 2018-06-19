using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBoderScene : MonoBehaviour {


    public GameObject[] borders;
    private int newVec;

    private Scene[] sceneList = new Scene[4];
    private int count;
	// Use this for initialization
	void Start () {
        count = 0;
        newVec = 15;
        GameCondition.pauseGame = false;
        //int sceneNum = Random.Range(0, borders.Length);
        //Instantiate(borders[sceneNum], new Vector3(0, newVec, transform.position.z), Quaternion.identity);
        //load the first 2 scene
       // SceneManager.LoadScene(0, LoadSceneMode.Additive);
        //queue[1] = 0;
        //SceneManager.UnloadSceneAsync(0);

        //int sceneNum = Random.Range(1, 4);
        //borderMap[sceneNum] = true;
        //SceneManager.LoadScene(sceneNum, LoadSceneMode.Additive);
        //queue[2] = sceneNum;

        //Scene s = SceneManager.GetSceneAt(0);
        //SceneManager.LoadScene(sceneNum, LoadSceneMode.Additive);

    }
	
	// Update is called once per frame
	void Update () {
        
		if(MoveUp.cameraDis >= count)
        {
            int sceneNum = Random.Range(0, borders.Length);
            //SceneManager.LoadScene(sceneNum, LoadSceneMode.Additive);
            Instantiate(borders[sceneNum], new Vector3(0, newVec,transform.position.z), borders[sceneNum].transform.rotation);
            newVec += 10;
            count += 10;
            //transform.position = new Vector3(0, 0, transform.position.z);
        } 
	}


    void setBorder()
    {
        if (transform.position.y <= -10)
        {
            int sceneNum = Random.Range(1, 10);
            SceneManager.LoadScene(sceneNum, LoadSceneMode.Additive);
            //queue[queue.Length - 1] = sceneNum;

            //set the condition back
            transform.position = new Vector3(0, 0, transform.position.z);


        }
    }


   // void unload()
   // {
        //unload if not empty
   //     if(queue[0] != -1)
    //    {
    //        SceneManager.UnloadSceneAsync(queue[0]);
   //         borderMap[queue[0]] = false;
    //    }

        //shift left
    //    for(int i = 0; i < queue.Length-1; i++)
    //    {
   //         queue[i] = queue[i + 1];
    //    }

       
        //queue[queue.Length - 1] = -1;

  //  }
}
