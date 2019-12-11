using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour
{
    public float hoverForce = 6f;
    public static bool complete = false;
    float fruitCount = 0;
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "orange" | other.name == "lime" | other.name == "banana")
        {
            fruitCount += 1;

        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.name == "orange" | other.name =="lime" | other.name == "banana") {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
    }


    public void OnTriggerExit(Collider other)
    {
        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        if (other.name == "orange" | other.name == "lime" | other.name == "banana")
        {
        }
    }

    public void Update()
    {
        //follow hand around
        if (fruitCount > 0)
        {
            complete = true;
        }
    }
}
