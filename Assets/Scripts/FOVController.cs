using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class FOVController : MonoBehaviour
{
    public static FOVController instance;
    public CinemachineVirtualCamera cam;

    public float baseFOV;
    public float maxFOV;

    private float targetOrthoSize;
    public float smoothSpeed;

    void Awake()
    {
        instance = this;
        targetOrthoSize = baseFOV;
    }
    public void SetRatio(float r)
    {
        targetOrthoSize = baseFOV + r * (maxFOV - baseFOV);
    }

    void FixedUpdate()
    {
        cam.m_Lens.OrthographicSize = Mathf.SmoothStep(cam.m_Lens.OrthographicSize, targetOrthoSize,Time.fixedDeltaTime * smoothSpeed);
    }
}
