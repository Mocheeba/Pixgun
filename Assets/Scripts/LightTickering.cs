using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightTickering : MonoBehaviour
{
    public bool isFlickering;
    public float FlickerTime;
    public float RandomIntensity;

   // public float randomRadiusTime;

    public bool flickeringLight_1;
    public bool lightIntensityChanges;
    public bool RadiusLight;

    Light2D myLight;

    void Start()
    {
        myLight = GetComponent<Light2D>();
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

        if (flickeringLight_1)
        {
            //Thickering Lights
            myLight.enabled = false;
            FlickerTime = Random.Range(0.0f, 0.26f);
            yield return new WaitForSeconds(FlickerTime);
            this.gameObject.GetComponent<Light2D>().enabled = true;
            isFlickering = false;
            Debug.Log("Light intensity changes");
        }

        if (lightIntensityChanges)
        {
            Debug.Log("Light intensity changes");
            //Light intensity changes
            RandomIntensity = Random.Range(0f, 3.1f);
            this.gameObject.GetComponent<Light2D>().intensity = 1;
            FlickerTime = Random.Range(0.0f, 0.5f);
            yield return new WaitForSeconds(FlickerTime);
            RandomIntensity = Random.Range(0f, 3.1f);
            this.gameObject.GetComponent<Light2D>().intensity = RandomIntensity;
            isFlickering = false;
        }

        if (RadiusLight)
        {
            //Light Outer radius changes
            Debug.Log("Light radius changes");
            RandomIntensity = Random.Range(0f, 10.0f * Time.deltaTime);
            this.gameObject.GetComponent<Light2D>().pointLightOuterRadius = 20;
            FlickerTime = Random.Range(1.0f, 10.5f);
            yield return new WaitForSeconds(FlickerTime);
            RandomIntensity = Random.Range(1f, 10.1f);
            this.gameObject.GetComponent<Light2D>().pointLightOuterRadius = RandomIntensity;
            isFlickering = false;
        }

        //if (flickeringLight_4)
        //{
        //    //Chooses between 1 and 2
        //    FlickerMode = Random.Range(1, 3);
        //    isFlickering = false;
        //}
    }    
}
