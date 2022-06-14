using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggresiveWeapon : Weapon
{
    private List<IDamageable> detectedDamageable = new List<IDamageable>();
    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();
    }    

    public void AddToDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Debug.Log("Added");

            detectedDamageable.Add(damageable);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        Debug.Log("Remove from Detected");

        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Debug.Log("Removed");

            detectedDamageable.Remove(damageable);
        }
    }
}
