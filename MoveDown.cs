using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public static float speed = .05f;
    private float distance;
    private Vector3 startpos;
    private Vector3 endpos;
    private float journeyDist;
    // Use this for initialization
    void Start()
    {
        

        startpos = transform.position;
        endpos = new Vector3(transform.position.x, -15, transform.position.z);
        //speed = 1.5f;
        distance = transform.position.y;
        //speed = 1.5f;
        GameCondition.pauseGame = false;
        journeyDist = Vector3.Distance(startpos, endpos);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameCondition.pauseGame == false)
        {
            Move();
        }

    }

    private void Move()
    {
        if (speed <= .1f)
        {
           speed += 0.000001f;
        }
        //float step = (speed * Time.deltaTime)/ journeyDist;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, distance, transform.position.z), speed);
        distance -= 1f;
        //float fracJourney = step / journeyDist;
        //transform.position = Vector3.Lerp(startpos, endpos, 0.1f);
    }
}
