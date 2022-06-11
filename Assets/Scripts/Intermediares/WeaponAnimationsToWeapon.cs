using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationsToWeapon : MonoBehaviour
{
    private Weapon weapon;
    private void Start()
    {
        weapon = GetComponentInParent<Weapon>();
    }

   private void AnimationFinishTrigger()
    {
        weapon.AnimationFinishTrigger();
    }
}
