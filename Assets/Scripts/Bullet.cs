using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;
    Vector2 baseVelocity;

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
    void FixedUpdate()
    {
        transform.Translate(moveDirection * moveSpeed * Time.fixedDeltaTime);
        transform.Translate(baseVelocity * Time.fixedDeltaTime, Space.World);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        SetMoveDirection(dir, 5, Vector2.zero);
    }
    public void SetMoveDirection(Vector2 dir, float speed)
    {
        SetMoveDirection(dir, speed, Vector2.zero);
    }
    public void SetMoveDirection(Vector2 dir, float speed, Vector2 parentVelocity)
    {
        baseVelocity = parentVelocity;
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
