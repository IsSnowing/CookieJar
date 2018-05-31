using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed;
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
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, distance, transform.position.z), step);
        distance -= 1;
    }
}
