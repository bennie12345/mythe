using UnityEngine;
using System.Collections;

public class FishEnemyDeath : EnemyDeath, IKillable
{

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        StoneEnemy = ObjectNames.FishStoneEnemyName;
        SlicedEnemy = ObjectNames.FishSlicedEnemyName;
        DisintegratedEnemy = ObjectNames.FishEnemyDisintegratedName;
        DeadEnemy = ObjectNames.DeadFishName;
    }

}
