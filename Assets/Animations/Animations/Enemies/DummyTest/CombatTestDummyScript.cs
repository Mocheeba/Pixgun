using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTestDummyScript : MonoBehaviour, IDamageable
{
    private Animator anim;

    public void Damage(float amount)
    {
        Debug.Log(amount + " Damage taken.");
    }

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }
}
