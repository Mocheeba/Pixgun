using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    public Vector3 respawnPoint;

     

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
        respawnPoint = new Vector3(-156.0f, -69.0f, 0.0f);
    }
    private void Update()
     {
        if (Input.GetKeyDown(KeyCode.T))
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
          StartCoroutine(Invunerability());

          anim.ResetTrigger("hurt");
        }
        else
        {
             if (!dead)
             {
                 //SoundMenager.instance.PlaySound(deadSound);
                 Debug.Log("dead");
                 anim.SetTrigger("die");
                 dead = true;
                 Respawn();

             }   
        }
    }

    public void Respawn()
    {   

        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        StartCoroutine(Invunerability());
        transform.position = respawnPoint;

        Debug.Log("Obecny checkpoint = " + respawnPoint );
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "CheckPointTwo")
        Debug.Log("Found a Checkpoint on Player Scripts");
        respawnPoint = new Vector3(-213.0f, -68.0f, 8.0f);
        
        // Play changing animation
        // Play Sound
        // deactivate checkpoint
   }

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

     public void AddHealth(float _value)
     {currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);}
     
}