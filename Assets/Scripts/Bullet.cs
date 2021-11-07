using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Vector2 moveDirection;
    protected float moveSpeed;
    Vector2 baseVelocity;

    public LayerMask targetMask;

    public ParticleSystem destroyParticles;

    private void OnEnable()
    {
        Invoke("DestroyBullet", 5f);
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


    public void DestroyBullet()
    {
        if (destroyParticles)
        {
            GameObject particles = Instantiate(destroyParticles.gameObject, transform.position, Quaternion.identity);
            particles.GetComponent<ParticleSystem>().Play();
            Destroy(particles, 1f);
        }
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == (col.gameObject.layer & targetMask.value))
        {
            Entity hit = col.gameObject.GetComponent<Entity>();
            if(hit != null)
            {
                hit.TakeDamage(1);
            }
            Bullet bullet = col.gameObject.GetComponent<Bullet>();
            if(bullet != null)
            {
                bullet.DestroyBullet();
            }
            DestroyBullet();
        }
    }
}
