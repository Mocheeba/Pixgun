using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightTickering : MonoBehaviour
{
    public bool isFlickering;
    public int FlickerMode;
    public float FlickerTime;
    public float RandomIntensity;

    UnityEngine.Rendering.Universal.Light2D myLight;

    void Start()
    {
        myLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        isFlickering = false;
    }

    void Update()
    {
        if(isFlickering == false)
        {
            StartCoroutine(FlickerLight());
        }
    }

    IEnumerator FlickerLight()
    {
        isFlickering = true;

        if (FlickerMode == 1)
        {
            this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = false;
            FlickerTime = Random.Range(0.0f, 0.26f);
            yield return new WaitForSeconds(FlickerTime);
            this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = true;
            isFlickering = false;
        }

        if (FlickerMode == 2)
        {
            //Light intensity changes
            RandomIntensity = Random.Range(0f, 3.1f);
            this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1;
            FlickerTime = Random.Range(0.0f, 0.5f);
            yield return new WaitForSeconds(FlickerTime);
            RandomIntensity = Random.Range(0f, 3.1f);
            this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = RandomIntensity;
            isFlickering = false;
        }

        if (FlickerMode == 3)
        {
            //Light Outer radius changes
            RandomIntensity = Random.Range(0f, 10.0f);
            this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 1;
            FlickerTime = Random.Range(0.0f, 0.5f);
            yield return new WaitForSeconds(FlickerTime);
            RandomIntensity = Random.Range(0f, 10.1f);
            this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = RandomIntensity;
            isFlickering = false;
        }

        if (FlickerMode == 4)
        {
            //Chooses between 1 and 2
            FlickerMode = Random.Range(1, 3);
            isFlickering = false;
        }
    }    
}
