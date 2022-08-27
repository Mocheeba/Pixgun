using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggresiveWeapon : Weapon
{
    protected SO_AggresiveWeaponData aggresiveWeaponData;

    private List<IDamageable> detectedDamageable = new List<IDamageable>();

    protected override void Awake()
    {
        base.Awake();

        if (weaponData.GetType() == typeof(SO_AggresiveWeaponData))
        {
            aggresiveWeaponData = (SO_AggresiveWeaponData)weaponData;
        }
        else
        {
            Debug.LogError("Wrong data for the weapon");
        }
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = aggresiveWeaponData.AttacksDetails[attackCounter];

        foreach (IDamageable item in detectedDamageable)
        {
            item.Damage(details.damageAmount);
        }
    }

    public void AddToDetected(Collider2D collision)
    {
        Debug.Log("Added to DETECTED!");

        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            detectedDamageable.Add(damageable);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        Debug.Log("Removed From Detected 2D");

        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            detectedDamageable.Remove(damageable);
        }
    }

}
