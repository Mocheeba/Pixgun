using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lastTeleport : MonoBehaviour
{
    private GameObject nextLevel;
  

    
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                SceneManager.LoadScene("Storyboards_End", LoadSceneMode.Single);
                Debug.Log("LastLevel");
            } 
        }
        
    


}
