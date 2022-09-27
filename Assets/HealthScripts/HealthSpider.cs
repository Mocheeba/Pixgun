using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthSpider : MonoBehaviour
{      
    [SerializeField] GameObject coinPrefab;

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

  
    private void Update()
     {
        if (Input.GetKeyDown(KeyCode.K))
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
                 SoundMenager.instance.PlaySound(deadSound);
                 Debug.Log("dead");
                 anim.SetTrigger("dead");
                 dead = true;
                 Instantiate(coinPrefab, transform.position, transform.rotation); 
                 Destroy(gameObject, 2);
             }   
        }
        
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Weapon")
        {
            TakeDamage(1);
            Debug.Log("HealthSpider ON HEALTH");
        }
     
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(0, 12,true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(0, 12,false);
    }
     
}