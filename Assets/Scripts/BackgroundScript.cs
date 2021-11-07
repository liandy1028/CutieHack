using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public float moveRatio;
    public Vector3 offset;
    public Transform target;
    void Update()
    {
        transform.position = target.transform.position*moveRatio + offset;
    }
}
