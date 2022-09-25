using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour
{      

    private NPC_Controller npc;
    #region Checkpoints
     [Header("CheckPoints Settings")]
     [SerializeField] Transform respawnStart;
     [SerializeField] Transform currentRespawn;
     [SerializeField] Transform respawnPoint1;
     [SerializeField] Transform respawnPoint2;

     [SerializeField] Transform respawnPoint3;

     [SerializeField] Transform respawnPoint4;
   #endregion 
 

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
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(1);
        }

        if (inDialogue())
        {  

        }
    
    }
    private void Awake()
    {
        currentRespawn.position = respawnStart.position;

        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        RB = GetComponentInParent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        
    }


    private bool inDialogue()
    {
        if(npc != null)
            return npc.ActiveDialogue();
        else
            return false;
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
                 anim.SetTrigger("die");
                 dead = true;
                 //Invoke("Respawn", 1.0f);
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
        transform.position = currentRespawn.position;
        

        Debug.Log("Obecny checkpoint = " + currentRespawn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "CheckPoint")
        {
            Debug.Log("Czekpoint1");
            currentRespawn = collision.transform;
        }
        else if(collision.transform.tag == "CheckPoint2")
        {
             Debug.Log("Czekpoint2");
             currentRespawn = collision.transform;
        }

        //   else if(collision.gameObject.name == "CAT")
        //   {
        //       if(Input.GetKeyDown(KeyCode.R))
        //         collision.gameObject.GetComponent<NPC_Controller>().ActiveDialogue();
              
        //   }
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            npc = collision.gameObject.GetComponent<NPC_Controller>();

            if(Input.GetKey(KeyCode.G))
                npc.ActiveDialogue();
        }
    }

   
    private void OnTriggerExit2D(Collider2D other)
    {
        npc = null;
    }

 
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.transform.tag == "Enemy");
    //     {
    //           Debug.Log("Spider");
    //           TakeDamage(1);
    //     }
    // }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.GameObject.tag == "CAT");
    //     {
    //           if(Input.GetKeyDown(KeyCode.E))
    //             collision.gameObject.GetComponent<NPC_Controller>().active = true;
    //     }
    // }



    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(7, 9, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 9, false);
    }

     public void AddHealth(float _value)
     {currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);}
     
}