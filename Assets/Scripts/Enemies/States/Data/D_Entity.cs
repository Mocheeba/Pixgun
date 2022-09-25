using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    [Header("SoundsClip")]
    [SerializeField] public AudioClip spiderAttackSound;
    [SerializeField] public AudioClip movementSound;

    [SerializeField] public AudioClip dashSound;

    [SerializeField] public AudioClip attackSound;

    [SerializeField] public AudioClip lookingForplayer;

    public float maxHealth = 30f;

    public float damageHopSpeed = 3f;

    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;
    public float groundCheckRadius = 0.3f;

    public float minAgroDistance = 3f;
    public float maxAgroDistance = 4f;

    public float stunResistance = 3f;
    public float stunRecoveryTime = 2f;

    public float closeRangeActionDistance = 1f;

    public GameObject hitParticle;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
