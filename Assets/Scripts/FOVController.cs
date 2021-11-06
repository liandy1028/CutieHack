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

    void Awake()
    {
        instance = this;
    }
    public void SetRatio(float r)
    {
        cam.m_Lens.OrthographicSize = baseFOV + r * (maxFOV - baseFOV);
    }
}
