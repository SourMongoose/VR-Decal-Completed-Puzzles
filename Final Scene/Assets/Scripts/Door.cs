using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool open = false;
    AudioSource aus;

    void Start()
    {
        aus = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (ChessPiece.complete && transform.rotation.y > -0.75f)
        {
            transform.Rotate(0, Time.deltaTime * -90, 0);
        }

        if (!open && ChessPiece.complete)
        {
            open = true;
            aus.Play();
        }
    }
}
