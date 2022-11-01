using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPlayer : CoreComponent
{

    [SerializeField] private AudioClip coinPickupSound;
    public int coins;
    public Text coinsCount;
    
    private void Start() {
    }

   private void OnTriggerEnter2D (Collider2D other)
   {
        if(other.CompareTag("Coins"))
        {
            SoundMenager.instance.PlaySound(coinPickupSound);
            Debug.Log("Coins");
            coins++;
            coinsCount.text = "" + coins.ToString();
            Destroy(other.gameObject);
        }
   }


   
}
