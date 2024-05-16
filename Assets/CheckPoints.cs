using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{ 
    [SerializeField] Transform teleportUI;
   [SerializeField] private AudioClip checkPointActiveSound;
   [SerializeField] private Animator anim;
   private Collider2D _collider;

private void Start() {
    anim = GetComponent<Animator>();
    _collider = GetComponent<Collider2D>();
}
   private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "Player")
        Debug.Log("Found a PLAYER on CheckPoints Scripts");
        anim.SetTrigger("appear");
        SoundMenager.instance.PlaySound(checkPointActiveSound);
        _collider.enabled = false;
        ShowUI();

   }
   private void OnTriggerExit2D(Collider2D collision)
   {
        HideUI();
   }
    private void ShowUI()
    {
        teleportUI.gameObject.SetActive(true);
        Debug.Log("Show UI");
    }

   private void HideUI()
    {
        teleportUI.gameObject.SetActive(false);
        Debug.Log("Hide UI");
    }
    
}
