using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPlayer : CoreComponent
{

    [SerializeField] private AudioClip coinPickupSound;
    public int coins;
    public Text coinsCount;
    public Rigidbody2D RB { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        RB = GetComponentInParent<Rigidbody2D>();

    }

    private void Start() {
        coinsCount.text = "Coins: " + 0;
    }

   private void OnTriggerEnter2D (Collider2D other)
   {
        if(other.CompareTag("Coins"))
        {
            SoundMenager.instance.PlaySound(coinPickupSound);
            Debug.Log("Coins");
            coins++;
            Destroy(other.gameObject);
            coinsCount.text = "" + coins.ToString();
        }
   }


   
}
