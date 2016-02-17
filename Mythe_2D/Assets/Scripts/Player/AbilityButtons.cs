using UnityEngine;
using System.Collections;

public class AbilityButtons : MonoBehaviour {

    private CooldownManager _cooldownManager;
    private Player _playerScript;

    [SerializeField]private GameObject effectCollider;
    [SerializeField]private ParticleSystem particles;
    [SerializeField]private Transform parentObject;
    [SerializeField]private GameObject Laserbeam;

    private float _laserCooldown = 0;
    private float _medusaCooldown = 0;
    private float _swordCooldown = 0;
    private float _minCooldown = 0;

    void Start()
    {
        _playerScript = GetComponentInParent<Player>();
        _cooldownManager = GetComponentInParent<CooldownManager>();
        this.gameObject.tag = Tags.abilityButtonsTag;
    }

    void Update()
    {
        ResetCooldowns();
    }

    public void UseSword(float SwordCD)
    {
        if (_playerScript.UsingSword == false && _swordCooldown <= _minCooldown) 
        {
            _playerScript.UsingSword = true;
            _swordCooldown = SwordCD;
            _cooldownManager.SwordCooldown = _swordCooldown;
        }
    }

    public void UseLasor(float LaserCD)
    {
        if (_laserCooldown <= _minCooldown)
        {
            StartCoroutine(ActivateTimer());
            _laserCooldown = LaserCD;
            _cooldownManager.LaserCooldown = _swordCooldown;
        }
    }

    IEnumerator ActivateTimer()
    {
        Laserbeam.SetActive(true);
        yield return new WaitForSeconds(2);
        Laserbeam.SetActive(false);

    }

    public void UseMedusaHead(float MedusaCD)
    {
        if (_medusaCooldown <= _minCooldown)
        {
            ParticleSystem instantiatedObject = Instantiate(particles, transform.position, Quaternion.Euler(0, 90, -90)) as ParticleSystem;
            instantiatedObject.transform.parent = parentObject;
            Instantiate(effectCollider);

            _medusaCooldown = MedusaCD;
            _cooldownManager.MedusaCooldown = _medusaCooldown;
        }
    }

    public void ResetCooldowns()
    {
        if(_cooldownManager.MedusaCooldown <= _minCooldown)
        {
            _medusaCooldown = _cooldownManager.MedusaCooldown;
        }
<<<<<<< HEAD
        if (_cooldownManager.LaserCooldown <= _minCooldown) 
        {
            _laserCooldown = _cooldownManager.LaserCooldown;        
=======
        if (_cooldownManager.SwordCooldown <= _minCooldown)
        {
            _swordCooldown = _cooldownManager.SwordCooldown;
>>>>>>> 826eb8049153f449f8031ddb304bf9cbd5e28d93
        }
    }

}
