using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCondition : MonoBehaviour {

    public static bool pauseGame = false;

    public void StartGame()
    {
        pauseGame = true;
    }

}
