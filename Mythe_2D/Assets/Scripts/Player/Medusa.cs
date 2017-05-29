using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medusa : Ability {

    void OnEnable()
    {
        AbilitiesButtons.OnUseMedusa += UseAbility;
    }

    void OnDisable()
    {
        AbilitiesButtons.OnUseMedusa -= UseAbility;
    }
}
