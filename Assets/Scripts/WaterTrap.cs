using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterTrap : MonoBehaviour
{
     public Transform player;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
       this.player = GameObject.FindWithTag("Player").transform; 
    }
   /// <summary>
   /// OnTriggerEnter is called when the Collider other enters the trigger.
   /// </summary>
   /// <param name="other">The other Collider involved in this collision.</param>
   private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "Player")
        Debug.Log("Dead!");
        Destroy(player.gameObject);
   }

}
