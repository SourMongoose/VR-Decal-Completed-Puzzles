using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic : MonoBehaviour
{
    bool open = false;
    AudioSource background;

    void Start()
    {
        background = GetComponent<AudioSource>();
        background.Play();
    }

    void Update()
    {
        if (!open && ChessPiece.complete && hover.complete)
        {
            open = true;
            background.Stop();
        }
    }
}
