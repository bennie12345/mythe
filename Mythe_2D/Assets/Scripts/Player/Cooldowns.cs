using UnityEngine;
using System.Collections;

public class Cooldowns : MonoBehaviour {

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
    private float _swordCooldown;
    public float SwordCooldown
    {
        get
        {
            return _swordCooldown;
        }
        set
        {
            _swordCooldown = value;
        }
    }
    private float _laserCooldown;
    public float LaserCooldown
    {
        get
        {
            return _laserCooldown;
        }
        set
        {
            _laserCooldown = value;
        }
    }

    private void Update () {
        ResetCooldown();
	}

    private void ResetCooldown()
    {
        if (_medusaCooldown >= _minCooldown)
        {
            _medusaCooldown -= Time.deltaTime;
        }
        if (_laserCooldown >= _minCooldown)
        {
            _laserCooldown -= Time.deltaTime;
        }
        if (_swordCooldown >= _minCooldown)
        {
            _swordCooldown -= Time.deltaTime;
        }
    }
}
