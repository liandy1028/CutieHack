using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletpool
{
    public GameObject pooledBullet;
    private bool notEnoughBulletsInPool = true;

    private List<GameObject> bullets;
    private Transform managerTransform;


    // Start is called before the first frame update
    public bulletpool(GameObject prefab, Transform parent)
    {
        pooledBullet = prefab;
        managerTransform = parent;
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (notEnoughBulletsInPool)
        {
            GameObject bul = GameObject.Instantiate(pooledBullet, managerTransform);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }

        return null;
    }
}
