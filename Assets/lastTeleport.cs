using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lastTeleport : MonoBehaviour
{
    private GameObject nextLevel;
  

    private void Awake() {
        //nextScene = GetComponent<>
    }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                SceneManager.LoadScene("endofstory", LoadSceneMode.Single);
                Debug.Log("LastLevel");
            } 
        }
        
    


}
