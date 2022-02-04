using UnityEngine;

//-----------------------------------------------------------------------
// <copyright file="C:\Users\dered\OneDrive\Documents\VFS\Scrapped\GAME\5818_Scrapped2\Assets\Scripts\Pickups\TurretItem.cs" company="Amateur Hour">
//     Author: @deredhuzent (Dery Escoto)
//     Copyright (c) All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

public class TurretItem : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 50f;
   
    // This is either -1f or 1
    [SerializeField]
    float startingDirection = 1.0f;

    [SerializeField]
    float minRotationDegrees = -60f;
    [SerializeField]
    float maxRotationDegrees = 60f;

    float currentDirection = 1.0f;
    float currentRotationDegrees = 0;

    Quaternion originalRotation = Quaternion.identity;

    void Start()
    {
        currentDirection = startingDirection;
        // Use initial object rotation as a reference
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        // increase the current angle
        currentRotationDegrees += rotationSpeed * currentDirection * Time.deltaTime;
        // clamp angle between the limits
        currentRotationDegrees = clampAngle(currentRotationDegrees, minRotationDegrees, maxRotationDegrees);

        // If hit the limits, change the direction  <<-- -->>
        if (currentRotationDegrees == minRotationDegrees || currentRotationDegrees == maxRotationDegrees)
        {
            currentDirection *= -1f;
        }

        // Create rotation towards current angle
        Quaternion currentRotation = Quaternion.AngleAxis(currentRotationDegrees, transform.up);
        transform.localRotation = originalRotation * currentRotation;
    }

    float clampAngle(float angle, float min, float max)
    {
        if (angle < -360f)
        {
            angle += 360f;
        }

        if (angle > 360f)
        {
            angle -= 360f;
        }

        return Mathf.Clamp(angle, min, max);
    }
}
