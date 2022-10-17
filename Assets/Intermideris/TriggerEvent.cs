using UnityEngine;
using System.Collections;

public class TriggerEvent : MonoBehaviour {


public GameObject lightBulb = null;



void OnTriggerEnter(Collider other ){

if (other.name == "player") {

    lightBulb.SetActive (true);
}

}

void OnTriggerExit( Collider other){

if (other.name == "player") {

    lightBulb.SetActive(false);
}

}




}