using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class lightRadiusIntesity : MonoBehaviour
{ 
    
    float duration = 1.0f;
    float originalOuterRadius = 1.0f;

    public float intensityRange = 3.0f;
 

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

        float outerRadiusRange = 5.0f;
        float innerRadiusRange = outerRadiusRange;


        lt.intensity = Mathf.PingPong(Time.time, intensityRange);

        lt.pointLightOuterRadius = Mathf.PingPong(Time.time, outerRadiusRange);

        lt.pointLightInnerRadius = Mathf.PingPong(Time.time, (innerRadiusRange * 0.2f));

    }



}