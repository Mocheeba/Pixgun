using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerTeleportation : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip tpSound;
    
    [SerializeField] GameObject currentTeleporter;
    
    private GameObject teleportSound;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {
                SoundMenager.instance.PlaySound(tpSound);
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }

        else if (collision.CompareTag("lastTeleport"))
        {
            SceneManager.LoadScene("Storyboards_End", LoadSceneMode.Single);
            Debug.Log("LastLevel");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}