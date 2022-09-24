using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerRespawn : CoreComponent
{
    private Transform currentCheckpoint;
    private Health playerHealth;

    private void Awake() {
        playerHealth = GetComponent<Health>();
        Debug.Log("Playr respawn scrips");
    }    

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();

        // Move camera
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;

            // play Souind
            Debug.Log("collision with a checkpoint");
            collision.GetComponent<Collider>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
