using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float jumpNodeHeightRequirement = 0.8f;
    public float jumpModifer = 0.3f;
    public float jumpCheckOffset = 0.1f;

    [Header("Custom Behaviour")]
    public bool followEnabled = true;
    public bool jumpEnabled = true;
    public bool directionLookEnabled = true;

    private Path path;
    private int currentWaypoint = 0;
    bool isGrounded = false;
    Seeker seeker;
    Rigidbody2D rb;

    private void Start() {
        
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds); // Invoke function constantly 
    } 

    private void FixedUpdate() {
        if (targetInDistance() && followEnabled)
        {
            PathFollow();
        }
    }

    private void UpdatePath()
    {
        if (followEnabled && targetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow()
    {
        if (path == null) // make sure path is empty 
        {
            return;
        }
        
        // Reached end of path
        if(currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        // See if colliding with anything 
        isGrounded = Physics2D.Raycast(transform.position, -Vector3.up, -GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);


        // Direction Calculation
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        // Jump
        if( jumpEnabled && isGrounded)
        {
            if (direction.y > jumpNodeHeightRequirement)
            {
                rb.AddForce(Vector2.up * speed * jumpModifer);
            }
        }
         // Movement
         rb.AddForce(force);

        // Next Waypoint 
        float distance = Vector2.Distance(rb.position, Path.VectorPath(currentWaypoint));
        
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    // Directoin Graphics Handling
    if (directionLookEnabled)
    {       
        if (rb.velocity.x > 0.05f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, Transform.localScale.z);
        }


    }
   



}
