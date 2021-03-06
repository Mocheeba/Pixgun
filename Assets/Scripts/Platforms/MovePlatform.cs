using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public GameObject platformPathStart;
    public GameObject platformPathEnd;
    public int speed;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private Rigidbody2D rBody;

    // player

    private Rigidbody2D playerRB;
    private bool isOnPlatform;
    private Rigidbody2D platformRBody;
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }



    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        startPosition = platformPathStart.transform.position;
        endPosition = platformPathEnd.transform.position;
        StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
    }

    void Update()
    {
        if (rBody.position == endPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, startPosition, speed));
        }
        if (rBody.position == startPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
        }
    }

    IEnumerator Vector3LerpCoroutine(GameObject obj, Vector2 target, float speed)
    {
        Vector2 startPosition = obj.transform.position;
        float time = 0f;

        while (rBody.position != target)
        {
            rBody.MovePosition(Vector2.Lerp(startPosition, target, (time / Vector2.Distance(startPosition, target)) * speed));
            time += Time.deltaTime;
            yield return null;
        }
    }

    void FixedUpdate()
    {
        if (isOnPlatform)
        {
            playerRB.velocity = playerRB.velocity + platformRBody.velocity;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            platformRBody = col.gameObject.GetComponent<Rigidbody2D>();
            isOnPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            isOnPlatform = false;
            platformRBody = null;
        }
    }




}