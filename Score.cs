using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {

    public static int currentScore;
    public static int prevScore;

	// Use this for initialization
	void Awake () {
        //Debug.Log("this is highestscore " + GameController.HighestScore.ToString());
        currentScore = 0;
        if (prevScore != 0)
        {
            gameObject.GetComponent<Text>().text = "High Score: " + GameController.HighestScore.ToString() + '\n' + "Score: " + prevScore.ToString();
        }
        else
        {
            gameObject.GetComponent<Text>().text = "High Score: " + GameController.HighestScore.ToString();
        }

    }


    private void Update()
    {
        if (currentScore != 0)
        {
            updateScore();
            saveScore();
        }
        else
        {
            if (prevScore != 0)
            {
                gameObject.GetComponent<Text>().text = "High Score: " + GameController.HighestScore.ToString() + '\n' + "Score: " + prevScore.ToString();
            }
            else
            {
                gameObject.GetComponent<Text>().text = "High Score: " + GameController.HighestScore.ToString();
            }
        }
    }
    public void updateScore()
    {
        gameObject.GetComponent<Text>().text = currentScore.ToString();
    }

    public void saveScore()
    {
        if (GameCondition.pauseGame == true)
        {
            prevScore = currentScore;
            if (currentScore > GameController.HighestScore)
            {

                GameController.HighestScore = currentScore;
                GameController.Save();
            }
            
        }
    }
}
