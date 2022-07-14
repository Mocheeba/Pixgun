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
   }


}
