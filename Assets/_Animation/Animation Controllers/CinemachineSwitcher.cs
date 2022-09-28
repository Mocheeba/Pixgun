using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{
  [SerializeField] private InputAction action;

    private bool ChixieCamera = true;
  private Animator anim;

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
  }

private void SwichState() {
    if (ChixieCamera) {
        anim.Play("NPC");
    }
    else{
        anim.Play("ChixieCamera");
    }
        ChixieCamera = !ChixieCamera;
    }

    void OnTriggerEnter2D (Collider other)
    {
        Debug.Log("Objec t enter");
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
