using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
   public Rigidbody2D rb { get; private set; }

   public Animator anim { get; private set; }

   public GameObject aliveGO { get; private set; } 

   public virtual void Start()
    {
        aliveGO = transform.Find("Alive").gameObject; // take reference from Hierarchy

        rb = aliveGO.GetComponent<Rigidbody2D>();

        anim = aliveGO.GetComponent<Animator>();
    }

}
