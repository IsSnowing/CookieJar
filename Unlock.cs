using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour {

    public string type;
    public List<GameObject> Locks = new List<GameObject>();
    //public GameObject itself;

    public void addLock(GameObject l)
    {
        Locks.Add(l);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("in collision");
        if (col.gameObject.tag == "Yellow" ||
            col.gameObject.tag == "Red" ||
            col.gameObject.tag == "Green" ||
            col.gameObject.tag == "Blue" ||
            col.gameObject.tag == "Ball")
        {
            gameObject.GetComponent<AudioSource>().Play();
            for(int i = 0; i < Locks.Count; i++)
            {
                Destroy(Locks[i]);
            }
            //Debug.Log("is touch");
            GameController.addCoin();
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
    
}
