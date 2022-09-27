// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SpikeHead : MonoBehaviour
// {
//     [SerializeField] private float speed;
//     [SerializeField] float range;
//     [SerializeField] float checkDalay;
//     private float checkTimer;
//     private Vector3 destination;

//     private Vector3[] directions = new Vector3[4];

//     private void Update() {
//         if(attacking)
//             transform.Translate(destination * checkTimer.deltaTime * speed);
//         else{
//             checkTimer += Time.deltaTime;
//             if(checkTimer > checkDalay)
//                 CheckForPlayer();   
//         }
//     }

//     private void CheckForPlayer()
//     {
//         CalculateDirections();

//         for (int i = 0; i < directions.Length; i++)
//         {
//             Debug.Draw(transform.position, directions[i], Color.red);
//         }
//     }    

//     private void CalculateDirections()
//     {

//         directions[0] = transform.right * range; // right
//         directions[1] = -transform.right * range; // right
//         directions[2] = transform.up * range; // right
//         directions[3] = -transform.up * range; // right
//     }
// }
