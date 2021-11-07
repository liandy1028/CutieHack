using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeRotation : MonoBehaviour
{
    public Sprite[] sprites;
    [ContextMenu("RANDOMIZE")]
    void Rotate()
    {
        int count = gameObject.transform.childCount;
        for(int x = 0;x < count;x++)
        {
            Transform child = gameObject.transform.GetChild(x);
            child.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360f));
            child.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 3)];
            child.localScale = new Vector3(Random.Range(2f, 4), Random.Range(0.5f, 3), 1);
        }
    }
}
