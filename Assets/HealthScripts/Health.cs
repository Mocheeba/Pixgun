using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour
{

    [SerializeField] GameManager GM;

    [Header ("Health")]
    
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    public Rigidbody2D RB { get; private set; }
    private bool dead;

    [Header ("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header ("Sound")]
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deadSound;

    private void Start() {
        
    }
    private void Update()
     {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        RB = GetComponentInParent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
          SoundMenager.instance.PlaySound(hurtSound);
          anim.SetTrigger("hurt");
          anim.ResetTrigger("hurt");
          StartCoroutine(Invunerability());
        }
        else
        {
             if (!dead)
             {
                 anim.SetTrigger("idle");
                 SoundMenager.instance.PlaySound(deadSound);
                 Debug.Log("dead");
                 anim.SetTrigger("die");
                 dead = true;
                 
                 Respawn();
                 Destroy(gameObject);
             }   
        }
    }

    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("idle");
        //StartCoroutine(Invunerability());
    }

     public void AddHealth(float _value)
     {currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);}
     

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}