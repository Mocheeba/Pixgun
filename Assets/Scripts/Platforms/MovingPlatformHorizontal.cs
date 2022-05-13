using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformHorizontal : MonoBehaviour
{
    public float speed; // speed
    public int startingPoint; // starting index
    public Transform[] points;

    private int i; // index of array

    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; //incrase the index
            if (i == points.Length)
            {
                i = 0; //reset index
            } 
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.position.y > transform.position.y)
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            Debug.Log("set parent ");
        }
    }
}
