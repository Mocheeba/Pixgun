using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // ustawiamy do jakiego tp 
    [SerializeField] private Transform destination;

    public Transform GetDestination()
    {
        return destination; 
    }


}
