using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{
  [SerializeField] private InputAction action;

    private Animator anim;
    private bool ChixieCamera = true;

  private void Awake() {
    anim = GetComponent<Animator>();
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
    action.performed += ctx => SwichState();
    Debug.Log("camera1");
  }

private void SwichState() {
    if (ChixieCamera) {
        Debug.Log("camera1");
        anim.Play("VirtualCemara_2");
    }
    else{
        anim.Play("Chixie_Camera");
        Debug.Log("camera_2");
    }
        ChixieCamera = !ChixieCamera;
    }

      void OnTriggerStay2D (Collider other)
    {
        Debug.Log("Stay ");
    }

      void OnTriggerExit2D (Collider other)
    {
        Debug.Log("Exit");
    }

}
