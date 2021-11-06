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

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.1f);    
    }
    
    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = 360 - transform.rotation.eulerAngles.z;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = bulletpool.bulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                // bul.transform.rotation = transform.rotation;
                // bul.transform.rotation = Quaternion.Euler(0,0,Mathf.Rad2Deg * Mathf.Atan2(bulDirY,bulDirX));
                bul.SetActive(true);
                bul.GetComponent<mushroombullet>().SetMoveDirection(bulDir, 20);

            angle += angleStep;
        }
    }

}
