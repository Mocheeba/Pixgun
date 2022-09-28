using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{ 
    
   [SerializeField] private AudioClip checkPointActiveSound;
   [SerializeField] private Animator anim;
   private Collider2D collider;


private void Start() {
    anim = GetComponent<Animator>();
    collider = GetComponent<Collider2D>();

}
   private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "Player")
        Debug.Log("Found a PLAYER on CheckPoints Scripts");
        anim.SetTrigger("appear");
        SoundMenager.instance.PlaySound(checkPointActiveSound);
        collider.enabled = false;
   }
}
