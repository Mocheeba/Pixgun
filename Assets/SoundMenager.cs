using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenager : MonoBehaviour
{
    [SerializeField] private AudioClip playerAttackSound;
    
    public static SoundMenager instance {get; private set; } // SoundMenager.instace and call method 
    private AudioSource source;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);

        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // Destroy duplcate object
        else if (instance != null && instance != this){
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip _sound){
        source.PlayOneShot(_sound);
    }
}
