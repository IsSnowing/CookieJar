using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {

    public static int currentScore;

	// Use this for initialization
	void Start () {
        Debug.Log("this is highestscore " + GameController.HighestScore.ToString());
        gameObject.GetComponent<Text>().text = GameController.HighestScore.ToString();
	}


    private void Update()
    {
        updateScore();
        saveScore();
    }
    public void updateScore()
    {
        gameObject.GetComponent<Text>().text = currentScore.ToString();
    }

    public void saveScore()
    {
        if(GameCondition.pauseGame == true &&  currentScore > GameController.HighestScore)
        {
           
            GameController.HighestScore = currentScore;
            GameController.Save();
            currentScore = 0;
            
        }
        
    }
}
