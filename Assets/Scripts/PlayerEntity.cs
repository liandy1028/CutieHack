using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    public LayerMask hazardMask;
    public ParticleSystem deathParticles;
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
    }
}
