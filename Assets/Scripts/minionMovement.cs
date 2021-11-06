using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionMovement : MonoBehaviour
{
    public float speed;
    public float sidewaysSpeedMultiplier;
    public float dist;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = player.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x) - 90f);
        if (Vector3.Distance(transform.position, player.transform.position) > dist) {    
            transform.position += transform.up * speed * Time.fixedDeltaTime;
        }
        else {
            transform.position += transform.right * sidewaysSpeedMultiplier * speed * Time.fixedDeltaTime;
        }
    }
}
