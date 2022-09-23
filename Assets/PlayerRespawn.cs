using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint;
    private Health playerHealth;

    private GameObject camObj;

    private void Start() {
         camObj = GameObject.Find("Chixie Camera");
         camObj.GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }
    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn(); // Restore player health and reset animation 

        // Move Camera to Checkpoint 
        
    }

    // Activate checkpoint 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentCheckpoint = collision.transform;
        SoundMenager.instance.PlaySound(checkpointSound);
        collision.GetComponent<Collider2D>().enabled = false;
        collision.GetComponent<Animator>().SetTrigger("appear");
    }
}
