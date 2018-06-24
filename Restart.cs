using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
    //public AudioSource destroySound;
    Animator anim;
    int explotionHash = Animator.StringToHash("BallExplotion");


    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
       
    }
    // Update is called once per frame
    //void OnDestroy()
   // {
    //    StartCoroutine(whenDestroy());
   // }


    IEnumerator whenDestroy()
    {
        //Debug.Log("isdestroy");
        
        anim.enabled = true;
        anim.SetTrigger(explotionHash);
        GameCondition.pauseGame = true;
        
        //gameObject.GetComponent<Rotation>().enabled = false;
        
        yield return new WaitForSeconds(.5f);
        GameController.Save();
        
        //MoveDown.speed = 1.5f;
        Destroy(gameObject);
        //Score.prevScore = Score.currentScore;
        SceneManager.LoadScene("Restart", LoadSceneMode.Additive);
        
    }

    public void startgame()
    {
        GameCondition.pauseGame = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("is touch");
        //Debug.Log(gameObject.tag);

        
        if (col.gameObject.tag != "Key")
        {

            if (Click.sound == true)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
            gameObject.GetComponent<Dragger>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(whenDestroy());
            
        }

    }
}
