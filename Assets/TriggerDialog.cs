using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    public GameObject canvasHolder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canvasHolder.SetActive(true);
        }
    }
}
 

