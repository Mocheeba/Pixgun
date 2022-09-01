using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAggresiveWeaponData", menuName = "Data/Weapon Data/Aggresive Weapons")]
public class SO_AggresiveWeaponData : SO_WeaponData
{
    [SerializeField] private WeaponAttackDetails[] attackDetails;

    public WeaponAttackDetails[] AttacksDetails { get => attackDetails; set => attackDetails = value; }

    private void OnEnable()
    {
        amountOfAttacks = attackDetails.Length;

        movementSpeed = new float[amountOfAttacks];

        for (int i = 0; i < amountOfAttacks; i++)
        {
            movementSpeed[i] = attackDetails[i].movementSpeed;
        }
    }
}
