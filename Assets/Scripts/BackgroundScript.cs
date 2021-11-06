using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        transform.position = target.transform.position*0.96f;
    }
}
