using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItem : MonoBehaviour
{

//-----------------------------------------------------------------------
// <copyright file="C:\Users\dered\OneDrive\Documents\VFS\Scrapped\GAME\Scrapped\Assets\Scripts\Event\FloatingItem.cs" company="Amateur Hour">
//     Author: @deredhuzent (Dery Escoto)
//     Copyright (c) All rights reserved.
// </copyright>
//-----------------------------------------------------------------------


    [SerializeField]
    private float _amplitude = 0.2f;
    [SerializeField]
    private float _frequency = 1f;


    Vector3 _offset = new Vector3();
    Vector3 _tempPosition = new Vector3();

    void Start()
    {
        _offset = transform.position;
    }

    void Update()
    {
        //float
        _tempPosition = _offset;
        _tempPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * _frequency) * _amplitude;

        transform.position = _tempPosition; 
    }
}
