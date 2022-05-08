using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private float startingHealth;

    [SerializeField] private int numberOfFlashes;

    private SpriteRenderer spriteRenderer;


    private Animator anim;
    private bool dead;
    public float currentHealth { get; private set; }
    private Rigidbody2D RB;


    private void Awake()
    {
        currentHealth = startingHealth;
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("minus 1 dmg");
            TakeDamage(1);
        }
    }

    public void TakeDamage(float _damage)
    {

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);


        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)  
            anim.SetTrigger("death");
            RB.bodyType = RigidbodyType2D.Static;
            dead = true;
        
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);

    }
}