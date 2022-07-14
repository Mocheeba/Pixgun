using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDummyController : MonoBehaviour
{
   [SerializeField]
   private float maxHealth;

   private float currentHealth;

   private float PlayerController pc;
   private GameObject aliveGO, brokenTopGo, brokenBotGO;
   private Rigidbody2D rbAlive, rbBrokenTop, rbBrokenBot;
   private Animator aliveAnim;

   private void Start()
   {
        currentHealth = maxHealth;

        pc = GameObject.Find("Player").GetComponent<PlayerController>();

        aliveGO = transform.Find("Alive").gameObject;
        brokenTopGO = transform.Find("Broken Top").gameObject;
        brokenBotGO = transform.Find("Broken Bottom").gameObject;

        aliveAnim = aliveGO.GetComponent<Animator>();
        

   }


}
