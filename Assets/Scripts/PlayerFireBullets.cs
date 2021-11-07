using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireBullets : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;

    public GameObject FiringPoint;

    public float firerate;
    public float bulletspeed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, firerate);
    }
    
    private void Fire()
    {
        if (!gameObject.activeSelf)
            return;
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = 360 - transform.rotation.eulerAngles.z;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPoolManager.instance.Pools["cutieBullet"].GetBullet();
                bul.transform.position = FiringPoint.transform.position;
                // bul.transform.rotation = transform.rotation;
                // bul.transform.rotation = Quaternion.Euler(0,0,Mathf.Rad2Deg * Mathf.Atan2(bulDirY,bulDirX));
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir, bulletspeed, GetComponentInParent<Rigidbody2D>().velocity);

            angle += angleStep;
        }
    }

}
