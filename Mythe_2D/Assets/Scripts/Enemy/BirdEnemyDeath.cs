using UnityEngine;
using System.Collections;

public class BirdEnemyDeath : EnemyDeath, IKillable
{

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        _stoneEnemy = ObjectNames.birdStoneEnemyName;
        _slicedEnemy = ObjectNames.birdSlicedEnemyName;
        _disintegratedEnemy = ObjectNames.birdEnemyDisintegratedName;
    }

}
