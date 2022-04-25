using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Player hurt anim
        animator.SetTrigger("Hurt");


        if (currentHealth < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("enemy died");
        // Die animation

        animator.SetBool("isDead", true);

        // Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;


    }
}
