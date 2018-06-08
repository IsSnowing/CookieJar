using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {


    // Update is called once per frame
    private void OnDestroy()
    {
        //Debug.Log("isdestroy");
        GameController.Save();
        GameCondition.pauseGame = true;
        MoveDown.speed = 1.5f;
        SceneManager.LoadScene("Restart", LoadSceneMode.Additive);
    }


    public void startgame()
    {
        GameCondition.pauseGame = false;
    }



}
