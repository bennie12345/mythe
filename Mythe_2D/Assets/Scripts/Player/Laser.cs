using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Ability {

    void OnEnable()
    {
        AbilitiesButtons.OnUseLaser += UseAbility;
    }

    void OnDisable()
    {
        AbilitiesButtons.OnUseLaser -= UseAbility;
    }
}
