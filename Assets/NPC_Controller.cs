using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    private GameObject dialogue;
    //public DialogueTrigger trigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            dialogue.SetActive(true);
            
        }
    }

    public bool ActiveDialogue()
    {
        return dialogue.activeInHierarchy;
    }
}
