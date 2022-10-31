using UnityEngine;
using System.Collections;

public class ChestTrigger : MonoBehaviour
{
  public GameObject myPrefab;

  [SerializeField] private float damage;

   [Header ("Chest Timers")] 
   [SerializeField] private float activationDelay;
   [SerializeField] private float activeTime;
   private Animator anim;
   private SpriteRenderer spriteRend;

   [Header ("SFX")]
   [SerializeField] private AudioClip chestTriggerSound;

    private bool triggered;
    private bool activate;

    private bool wasActive = false;

    private void Awake() {
    anim = GetComponent<Animator>();
    spriteRend = GetComponent<SpriteRenderer>();
   }


   private void OnTriggerEnter2D(Collider2D collision){
    if(collision.tag == "Player")
    {
        Debug.Log("Chest Player detected ");
        if(!triggered & !wasActive)
        {
            StartCoroutine(ActivateChestTrigger());
        }
        if (activate)
            collision.GetComponent<Health>().TakeDamage(damage);

        if (wasActive)
        {
            Debug.Log("Witaj po raz kolejny!");
             // Instantiate at position (0, 0, 0) and zero rotation.

        }
    }

   }
   private IEnumerator ActivateChestTrigger()
   {
         triggered = true;
         anim.SetBool("isActivated", true);
         spriteRend.color = Color.red;
         SoundMenager.instance.PlaySound(chestTriggerSound);

         yield return new WaitForSeconds(activationDelay);

         spriteRend.color = Color.white;
         activate = true;

         yield return new WaitForSeconds(activeTime);
         activate = false;
         triggered = false;
         anim.SetBool("notActive", true);
         wasActive = true;   
         Instantiate(myPrefab, transform.position, transform.rotation); 

   }
}
