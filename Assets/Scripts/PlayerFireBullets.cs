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

    public GameObject FiringPoint1;
    public GameObject FiringPoint2;

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

            GameObject bul1 = BulletPoolManager.instance.Pools["cutieBullet"].GetBullet();
                bul1.transform.position = FiringPoint1.transform.position;
                // bul.transform.rotation = transform.rotation;
                // bul.transform.rotation = Quaternion.Euler(0,0,Mathf.Rad2Deg * Mathf.Atan2(bulDirY,bulDirX));
                bul1.SetActive(true);
                bul1.GetComponent<Bullet>().SetMoveDirection(bulDir, bulletspeed, GetComponentInParent<Rigidbody2D>().velocity);
            GameObject bul2 = BulletPoolManager.instance.Pools["cutieBullet"].GetBullet();
                bul2.transform.position = FiringPoint2.transform.position;
                // bul.transform.rotation = transform.rotation;
                // bul.transform.rotation = Quaternion.Euler(0,0,Mathf.Rad2Deg * Mathf.Atan2(bulDirY,bulDirX));
                bul2.SetActive(true);
                bul2.GetComponent<Bullet>().SetMoveDirection(bulDir, bulletspeed, GetComponentInParent<Rigidbody2D>().velocity);

            angle += angleStep;
        }
    }

}
