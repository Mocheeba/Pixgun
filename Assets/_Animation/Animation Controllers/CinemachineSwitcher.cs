using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField] private InputAction action;

    [SerializeField] private CinemachineVirtualCamera vcam1; // chixie camera
    [SerializeField] private CinemachineVirtualCamera vcam2; // chixie camera 2
    [SerializeField] private CinemachineVirtualCamera cutSceneVcam; // cutscene cam

    private Animator anim;
    private bool ChixieCamera = true;
   
  private void Awake() {
   // anim = GetComponent<Animator>();
  }

  private void OnEnable()
  {
    action.Enable();
  }

  private void OnDisable()
  {
    action.Disable();
  }

  private void Start() {
    action.performed += _ => SwitchPriority();
  }
  private void SwitchPriority()
  {
    if(ChixieCamera)
    {
      Debug.Log("camera_1");
      vcam1.Priority = 0;
      vcam2.Priority = 1;
    }
    else if(vcam2) {
      Debug.Log("camera_2");
      vcam1.Priority = 1;
      vcam2.Priority = 0;
    }
    else if(cutSceneVcam) {
      Debug.Log("cutSceneVcam");
      vcam1.Priority = 1;
      vcam2.Priority = 0;
    }
    ChixieCamera = !ChixieCamera;
  }

    

// private void SwichState() {
//     if (ChixieCamera) {
//         Debug.Log("camera1");
//         anim.Play("VirtualCemara_2");
//     }
//     else{
//         anim.Play("Chixie_Camera");
//         Debug.Log("camera_2");
//     }
//         ChixieCamera = !ChixieCamera;
//     }

//       void OnTriggerStay2D (Collider other)
//     {
//         Debug.Log("Stay ");
//     }

//       void OnTriggerExit2D (Collider other)
//     {
//         Debug.Log("Exit");
//     }



}
