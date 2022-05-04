using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class lightRadiusIntesity : MonoBehaviour
{ 
    
    float duration = 1.0f;
    float originalOuterRadius = 1.0f;

    public float intensityRange = 1.0f;
 

    Light2D lt;
   

    void Start()
    {
        lt = GetComponent<Light2D>();

    }

    void Update()
    {
        //IncreaseOuterRadius();
        SmoothDampAngle();
    
    }

    void IncreaseOuterRadius()
    {
        var amplitude = Mathf.PingPong(Time.time, duration);

        // Transform from 0..duration to 0.5..1 range.
        amplitude = amplitude + duration / 1f + 1f;

        // Set light range.
        lt.pointLightOuterRadius = originalOuterRadius * amplitude;
    }

    void SmoothDampAngle()
    {
        float outerRadius = lt.pointLightOuterRadius;
        float innerRadius = lt.pointLightInnerRadius;
       // float dinstanceRadius = Mathf.Abs(innerRadius - (outerRadius - 2.0f));

        float dinstanceRadius = Mathf.Lerp(outerRadius, innerRadius, 2.0f);

        lt.intensity = Mathf.PingPong(Time.time, 10);

        lt.pointLightOuterRadius = Mathf.PingPong(Time.time, 10);

        lt.pointLightInnerRadius = Mathf.PingPong(Time.time / 1, dinstanceRadius);

        lt.intensity = Mathf.PingPong(Time.time / 2, intensityRange);
    }



}