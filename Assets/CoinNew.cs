using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinNew : MonoBehaviour
{
    public int value;
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            CoinCounterek.instance.IncraseCoins(value);
        }
    }
}
