using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateKey : MonoBehaviour {
    public List<GameObject> Locks;
    public GameObject key;
    public Color c;
    // Use this for initialization
    void Start () {
        create();
    }

    void create()
    {
        float x = UnityEngine.Random.Range(-3.0f, 3.0f);
        float y = UnityEngine.Random.Range(0.0f, 3.0f);
        Vector3 vector = new Vector3(x, transform.position.y - y, transform.position.z);
        GameObject b = Instantiate(key, vector, Quaternion.identity);
        //b.transform.parent = transform;
        b.transform.position = vector;
        b.GetComponent<Unlock>().Locks = Locks;
        b.GetComponent<SpriteRenderer>().color = c;
    }
}
