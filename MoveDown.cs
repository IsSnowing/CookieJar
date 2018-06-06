using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public static float speed = 1.5f;
    private float distance;
    // Use this for initialization
    void Start()
    {
        //speed = 1.5f;
        distance = transform.position.y;
        
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
        if (speed <= 5)
        {
            speed += 0.0001f;
        }
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, distance, transform.position.z), step);
        distance -= 1;
    }
}
