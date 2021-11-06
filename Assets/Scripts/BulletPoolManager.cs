using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    #region singleton
    public static BulletPoolManager instance;
    private void Awake() {
        instance = this;
    }

    #endregion

    [System.Serializable]
    public class Pool {
        public string key;
        public GameObject prefab;
    }
    public List<Pool> pools;
    public Dictionary<string, bulletpool> Pools;

    void Start() {
        Pools = new Dictionary<string, bulletpool>();
        foreach (Pool pool in pools) {
            Pools[pool.key] = new bulletpool(pool.prefab, transform);
        }
    }
}
