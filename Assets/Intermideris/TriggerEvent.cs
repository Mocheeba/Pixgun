using UnityEngine;
using System.Collections;

public class TriggerEvent : MonoBehaviour {


public GameObject lightBulb = null;



void OnTriggerEnter2D(Collider other ){

if (other.name == "Player") {
    Debug.Log("lightbulb on ");

    lightBulb.SetActive(true);
}

}

void OnTriggerExit2D( Collider other){

if (other.name == "Player") {
     Debug.Log("lightbulb off ");
    lightBulb.SetActive(false);
}

}




}