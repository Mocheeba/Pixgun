using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{ 
   [SerializeField] private GameObject light_1; 
   [SerializeField] private AudioClip lightTrigger;
   //[SerializeField] private Animator anim;
   private Collider2D collider;


private void Start() {
   // anim = GetComponent<Animator>();
    collider = GetComponent<Collider2D>();

}
   private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "Player")
        Debug.Log("Found a PLAYER on CheckPoints Scripts");
      //  anim.SetTrigger("appear");
        SoundMenager.instance.PlaySound(lightTrigger);
       // collider.enabled = false;
       light_1.SetActive(true);
   }
}
