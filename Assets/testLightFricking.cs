using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testLightFricking : MonoBehaviour
{
    [SerializeField] float betweenLightFlickers;
    [SerializeField] float lightFlickerMin;
    [SerializeField] float lightFlickerMax;
    [SerializeField] float beginningTime;

    UnityEngine.Rendering.Universal.Light2D myLight;

    private void Start()
    {
        myLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        StartCoroutine(StartScene());
    }

    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(beginningTime);
        StartCoroutine(LightFlicker());
    }
    IEnumerator LightFlicker()
    {
        yield return new WaitForSeconds(betweenLightFlickers);
        myLight.pointLightOuterRadius = Random.Range(lightFlickerMin, lightFlickerMax);
        StartCoroutine(LightFlicker());
    }
}
