using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    public int currentHealth;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 11;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 11;
    }
}