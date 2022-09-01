using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTestDummyScript : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject hitParticles; 

    private Animator anim;

    public void Damage(float amount)
    {
        Instantiate(hitParticles, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        Debug.Log(amount + " Damage taken.");
        anim.SetTrigger("damage");
        Destroy(gameObject);
    }

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }
}
