using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTestDummyScript : MonoBehaviour
{
    private Animator anim;

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }
}
