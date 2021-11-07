using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerEntity : Entity
{
    public LayerMask hazardMask;
    public ParticleSystem deathParticles;

    public Text DeathMessage;
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(1 << coll.gameObject.layer == (1 << coll.gameObject.layer & hazardMask.value))
        {
            //EntityDie();
        }
    }
    protected override void EntityDie()
    {
        base.EntityDie();
        GetComponent<SpriteRenderer>().enabled = false;
        deathParticles.Play();
        gameObject.SetActive(false);

        DeathMessage.enabled = true;
        Invoke("gamereset",2f);
    }

    void gamereset()
    {
        DeathMessage.enabled = false;
        SceneManager.LoadScene("SampleScene");
    }
}
