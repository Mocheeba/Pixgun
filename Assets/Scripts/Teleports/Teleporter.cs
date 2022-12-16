using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform TeleportUI;
    // ustawiamy do jakiego tp 
    [SerializeField] private Transform destination;

    public Transform GetDestination()
    {
        return destination; 
    }
    // play animation

}
