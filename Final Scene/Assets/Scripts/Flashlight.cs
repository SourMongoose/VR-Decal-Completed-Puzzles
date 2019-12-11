using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light light;
    public OVRInput.Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        light.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<OVRGrabbable>().isGrabbed)
        {
            light.GetComponent<Light>().enabled = true;

        }

        if (!transform.GetComponent<OVRGrabbable>().isGrabbed)
        {
            light.GetComponent<Light>().enabled = false;

        }
    }
}
