using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallexScript : MonoBehaviour
{
private Transform cameraTransform;
private Vector3 lastCameraPosition;

    void Start()
    {
        cameraTransform=Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }


    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        float parallaxEffectMultiplier = .5f;
        transform.position+=deltaMovement*parallaxEffectMultiplier;
        lastCameraPosition=cameraTransform.position;
    }
}
