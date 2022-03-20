using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoobaMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
    }

    void OnTriggerExit2D(Collider 2D other)
    {
        moveSpeed = -moveSpeed;
        FlipHoriontal();
    }

    void FlipEnemyFacing()
    {
        Transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), 1f);
    }
}
