using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap_1 : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("FireTrap Timers")]
    [SerializeField] private float activeDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered;//When trap is triggered
    private bool active;//When the trap is active and can hurt the player

    private Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(playerHealth != null && active)
        {
            playerHealth.TakeDamage(damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();

            if (!triggered)
                StartCoroutine(ActiveFireTrap());

            if (active)
                collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            playerHealth = null;
    }


    private IEnumerator ActiveFireTrap()
    {
        //turn the sprite red to notify the player and trigger the trap
        triggered = true;
        spriteRend.color = Color.red;

        //Wait for delay, active trap, turn on anim, raturn color back to normal
        yield return new WaitForSeconds(activeDelay);
        //spriteRend.color = Color.white; // turn the sprite back its to normal
        active = true;
        anim.SetBool("isActivated", true);

        //Wait until X seconds, deactivate map trap and reset all variables and animator
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("isActivated", false);

    }    

}
