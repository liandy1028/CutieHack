using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRotator : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    public float lerpFactor;
    void FixedUpdate()
    {
        float cAngle = transform.rotation.eulerAngles.z;
        float diff = Mathf.DeltaAngle(cAngle, cam.m_Follow.rotation.eulerAngles.z);
        float newAngle = Mathf.Lerp(cAngle, cAngle + diff, lerpFactor * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0,newAngle);
    }
}
