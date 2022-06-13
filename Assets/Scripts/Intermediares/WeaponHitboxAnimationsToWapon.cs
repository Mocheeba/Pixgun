using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitboxAnimationsToWapon : MonoBehaviour
{ 
    private AggresiveWeapon weapon;

    private void Awake()
    {
        weapon = GetComponentInParent<AggresiveWeapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        weapon.AddToDetected(collision);
    }    

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        weapon.RemoveFromDetected(collision);
    }

}
