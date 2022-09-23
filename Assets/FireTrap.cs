using UnityEngine;
using System.Collections;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float damage;

   [Header ("Firetrap Timers")] 
   [SerializeField] private float activationDelay;
   [SerializeField] private float activeTime;
   private Animator anim;
   private SpriteRenderer spriteRend;

    private bool triggered;
    private bool activate;

   private void Awake() {
    anim = GetComponent<Animator>();
    spriteRend = GetComponent<SpriteRenderer>();
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "Player")
    {
        if(!triggered)
        {
            StartCoroutine(ActivateFireTrap());
        }
        if (activate)
            collision.GetComponent<Health>().TakeDamage(damage);
    }
   }
   private IEnumerator ActivateFireTrap()
   {
         triggered = true;
         spriteRend.color = Color.red;
         yield return new WaitForSeconds(activationDelay);
         spriteRend.color = Color.white;
         activate = true;
         anim.SetBool("isActivated", true);


         yield return new WaitForSeconds(activeTime);
         activate = false;
         triggered = false;
         anim.SetBool("isActivated", false);

   }
}
