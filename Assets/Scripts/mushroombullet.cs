using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroombullet : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }
    
    // Start is called before the first frame update
    void Start()
    {
    //    moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        SetMoveDirection(dir, 5);
    }
    public void SetMoveDirection(Vector2 dir, float speed)
    {
        moveSpeed = speed;
        moveDirection = Vector2.up;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x) - 90f);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}