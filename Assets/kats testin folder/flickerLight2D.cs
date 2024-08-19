using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class flickerLight2D : MonoBehaviour
{
    public float baseIntensity = 1f;
    public float flickerSpeed = 1f;
    public float flickerIntensity = 1f;

    Light2D thisLight;

    private void Start()
    {
        thisLight = GetComponent<Light2D>();
    }

    private void LateUpdate()
    {
        thisLight.intensity = baseIntensity * Mathf.Sin(Time.time * flickerSpeed) * flickerIntensity;
    }
}
