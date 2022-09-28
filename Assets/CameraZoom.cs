// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CameraZoom : MonoBehaviour
// {
//     public bool ZoomActive;

//     public Vector3[] Target;

//     public Camera Cam;

//     public float Speed;

//     /// <summary>
//     /// Start is called on the frame when a script is enabled just before
//     /// any of the Update methods is called the first time.
//     /// </summary>
//     private void Start()
//     {
//         Cam = Camera.main;
//     }

//     private void LateUpdate() {
//         if(GetComponent<Camera>().orthographic){
//                 if (ZoomActive){
//             Cam.orthographicSize = Mathf.Lerp(Cam.ortographicSize, 3, Speed);}
//         else{
//             Cam.main.orthographicSize = Mathf.Lerp(Cam.ortographicSize, 3, Speed);
//         }

//      }
        
//     }
// }
