using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounterek : MonoBehaviour
{
    [SerializeField] private AudioClip coinPickupSound;
    public static CoinCounterek instance;

    public Text coinText;
    public int currentCoins = 0;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    private void Start() {
        coinText.text = " " + currentCoins.ToString();
    }
    public void IncraseCoins(int v)
    {
        SoundMenager.instance.PlaySound(coinPickupSound);
        currentCoins += v;
        coinText.text = " " + currentCoins.ToString();
    }

}
