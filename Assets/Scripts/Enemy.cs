using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] points;
    public float speed = 2f;
    public float WaitTime = 3f;
    bool CanGo = true;
    int i = 1;
    void Start()
    {
        gameObject.transform.position = new Vector3(points[0].position.x, transform.position.y, points[0].position.z);

    }

    void Update()
    {
        if (CanGo)
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);

        if (transform.position == points[i].position)
        {
            if (i < points.Length - 1)
                i++;
            else
                i = 0;

            CanGo = false;
            StartCoroutine(Waiting());
        }


    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(WaitTime);
        CanGo = true;
    }
}
