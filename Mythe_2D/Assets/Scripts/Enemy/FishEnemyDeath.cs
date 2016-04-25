using UnityEngine;
using System.Collections;

public class FishEnemyDeath : EnemyDeath, IKillable
{

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        _stoneEnemy = ObjectNames.fishStoneEnemyName;
        _slicedEnemy = ObjectNames.fishSlicedEnemyName;
        _disintegratedEnemy = ObjectNames.fishEnemyDisintegratedName;
        _deadEnemy = ObjectNames.deadFishName;
    }

}
