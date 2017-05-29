using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Ability {


	void OnEnable ()
	{
	    AbilitiesButtons.OnUseSword += UseAbility;
	}

	void OnDisable ()
    {
        AbilitiesButtons.OnUseSword -= UseAbility;
    }
}
