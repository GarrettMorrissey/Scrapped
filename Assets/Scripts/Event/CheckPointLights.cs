using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------
// <copyright file="C:\Users\dered\OneDrive\Documents\VFS\Scrapped\GAME\Scrapped\Assets\Scripts\Event\CheckPointLights.cs" company="Amateur Hour">
//     Author: Dery Escoto
//     Copyright (c) All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

public class CheckPointLights : MonoBehaviour
{
    Renderer rend;
    [SerializeField]
    private Material[] _material = null;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        //start with unchecked color
        rend.sharedMaterial = _material[0];

        // Invoke("ActivateCheckpointVFX", _delay);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //change to checked color 
            rend.sharedMaterial = _material[1];
        }
    }
}
