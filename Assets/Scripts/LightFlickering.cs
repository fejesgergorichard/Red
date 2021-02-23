using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickering : MonoBehaviour
{
    public float Amplitude = 3f;
    public float Speed = 5f;
    public GameObject FlickeringLight;
    public GameObject GlobalLight;

    Light light;
    float amp;
    float minRange;
    float maxRange;
    bool inc;
    bool dec;

    private void Start()
    {
        inc = false;
        dec = true; 
        amp = Amplitude / Speed;
        light = (Light)FlickeringLight.GetComponent("Light");
        maxRange = light.range + Amplitude;
        minRange = light.range - Amplitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (inc)
        {
            dec = false;
            light.range += amp;
            light.intensity += amp;
            GlobalLight.transform.Rotate(0, amp * 3, 0);

            if (light.range >= maxRange)
            {
                dec = true;
                inc = false;
            }
                
        }
        else if (dec)
        {
            inc = false;
            light.range -= amp;
            light.intensity -= amp;
            GlobalLight.transform.Rotate(0, -amp * 3, 0);

            if (light.range <= minRange)
                inc = true;
        }

        Behaviour halo = (Behaviour)FlickeringLight.GetComponent("Halo");
    }
}
