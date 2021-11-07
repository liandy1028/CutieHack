using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : Entity
{
    protected override void EntityDie()
    {
        //print("test");
        base.EntityDie();
        ScoreKeeper.scoreKeeper.IncrementScore();
        Destroy(gameObject);
    }
}
