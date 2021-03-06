using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroombullet : Bullet
{
    GameObject player;
    public float speedMultiplier;
    private bool straight;
    private void OnEnable()
    {
        straight = true;
        Invoke("Home", 1f);
        Invoke("Straight", 3f);
        Invoke("DestroyBullet", 10f);
    }
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update() {
        if (!straight) {
            Vector3 direction = player.transform.position - transform.position;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x) - 90f);
        }
    }
    void Home() {
        straight = false;
    }
    void Straight() {
        straight = true;
        moveSpeed *= speedMultiplier;
    }
}
