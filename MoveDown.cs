using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public static float speed = 1.5f;
    public float rate = 1.1f;
    private float distance;
    // Use this for initialization
    void Start()
    {
        distance = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

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
