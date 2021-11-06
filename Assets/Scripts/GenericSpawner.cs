using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct Spawnable
    {
        public GameObject toSpawn;
        public int weight;
    }

    public Spawnable[] spawns;
    public Vector2 spawnTime;
    public Vector2 spawnCount;
    public Vector2 spawnRadius;

    private float timer = 5f;
    private int weightTotal = 0;
    void Awake()
    {
        Random.InitState((int)Time.time);
        foreach(Spawnable spawn in spawns)
        {
            weightTotal += spawn.weight;
        }
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = Random.Range(spawnTime.x, spawnTime.y);
            int count = Random.Range((int)spawnCount.x, (int)spawnCount.y);
            for (int i = 0; i < count; i++)
            {
                float radius = Random.Range(spawnRadius.x, spawnRadius.y);
                float angle = Random.Range(0, 360f);
                Vector2 position = transform.position + Quaternion.Euler(0, 0, angle) * Vector2.up * radius;
                Instantiate(GetRandomFromWeight().toSpawn, position, Quaternion.identity);
            }
        }
    }

    private Spawnable GetRandomFromWeight()
    {
        int rand = Random.Range(1, weightTotal + 1);
        int current = 0;
        foreach (Spawnable spawn in spawns)
        {
            current += spawn.weight;
            if(current >= rand)
            {
                return spawn;
            }
        }
        return spawns[0];
    }

}
