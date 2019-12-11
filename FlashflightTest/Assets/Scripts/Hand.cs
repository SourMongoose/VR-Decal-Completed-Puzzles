using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    public Vector3 holdPosition = new Vector3(0, -0.025f, 0.03f);
    public Vector3 holdRotation = new Vector3(0, 180, 0);
    public OVRInput.Controller controller;

    private float indexState = 0;
    private float handState = 0;

    private bool grabbing = false;
    private Flashlight flashLight = null;

    public void Update() {
        indexState = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
        handState = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);

        if (grabbing && indexState <= 0.9f) {
            Release();
        }
    }

    public void OnTriggerStay(Collider other) {
       if (other.CompareTag("FlashLight")) {
             Debug.Log(grabbing + " " + indexState);
             if (!grabbing && indexState > 0.9f) {
                 GrabFlashLight(other.gameObject);
             }
        }
    }

    private void GrabFlashLight(GameObject flashlight) {
        grabbing = true;
        flashLight = flashlight.GetComponent<Flashlight>();
        //flashLight = flashlight;
        flashLight.transform.parent = transform;
        flashLight.transform.localPosition = holdPosition;
        flashLight.transform.localEulerAngles = holdRotation;
        flashLight.GetComponent<Rigidbody>().useGravity = false;
        flashLight.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Release() {
        flashLight.transform.parent = null;
        Rigidbody rigidbody = flashLight.GetComponent<Rigidbody>();
        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
        rigidbody.velocity = OVRInput.GetLocalControllerVelocity(controller);
        grabbing = false;
        flashLight = null;
    }
}
