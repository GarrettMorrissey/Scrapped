using UnityEngine;

//-----------------------------------------------------------------------
// <copyright file="C:\Users\dered\OneDrive\Documents\VFS\Scrapped\GAME\Scrapped\Assets\Scripts\Event\RotationItem.cs" company="Amateur Hour">
//     Author: @deredhuzent (Dery Escoto)
//     Copyright (c) All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

public class RotationItem : MonoBehaviour
{
    [SerializeField] 
    private float _rotateSpeed_x = 50f;
    [SerializeField] 
    private float _rotateSpeed_y = 0f;
    [SerializeField]
    private float _rotateSpeed_z = 0f;

  private void Update()
    {
        transform.Rotate(new Vector3(_rotateSpeed_x, _rotateSpeed_y, _rotateSpeed_z) * Time.deltaTime);
    }

    //TODO: stop after certain time
}
