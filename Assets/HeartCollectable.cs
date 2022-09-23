using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollectable : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip heartPickup;

    private void Start() {
        //Rotate();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundMenager.instance.PlaySound(heartPickup);
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }

    // private void Rotate()
    // {
    //       transform.localRotation = Quaternion.Euler(0, 180, -90);
    // }
   
    
}