using UnityEngine;
using System.Collections;

public class CooldownManager : MonoBehaviour {

    private float _minCooldown = 0;
    private float _medusaCooldown;
    public float MedusaCooldown
    {
        get
        {
            return _medusaCooldown;
        }
        set
        {
            _medusaCooldown = value;
        }
    }
	
	// Update is called once per frame
	void Update () {
        ResetMedusaCooldown();
	}

    void ResetMedusaCooldown()
    {
        if (_medusaCooldown >= _minCooldown)
        {
            _medusaCooldown -= Time.deltaTime;
        }
    }
}
