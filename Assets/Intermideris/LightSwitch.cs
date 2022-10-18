using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{ 
    
   [SerializeField] private AudioClip lightTrigger;
   [SerializeField] private GameObject lightTriggerGO;
   //[SerializeField] private Animator anim;
   private Collider2D collider;


private void Start() {
   // anim = GetComponent<Animator>();
    collider = GetComponent<Collider2D>();

}
   private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "Player")
        Debug.Log("Found a PLAYER on LIGHTS TRIGGER 1 Scripts");
      //  anim.SetTrigger("appear");
        SoundMenager.instance.PlaySound(lightTrigger);
       // collider.enabled = false;
       lightTriggerGO.SetActive(true);
       collider.enabled = false;
   }
}
