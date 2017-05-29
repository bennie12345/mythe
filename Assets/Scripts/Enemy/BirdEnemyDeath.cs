using UnityEngine;
using System.Collections;

public class BirdEnemyDeath : EnemyDeath, IKillable
{

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        StoneEnemy = ObjectNames.BirdStoneEnemyName;
        SlicedEnemy = ObjectNames.BirdSlicedEnemyName;
        DisintegratedEnemy = ObjectNames.BirdEnemyDisintegratedName;
        DeadEnemy = ObjectNames.DeadBirdName;
    }

}
