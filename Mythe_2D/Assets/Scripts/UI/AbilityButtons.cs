using UnityEngine;
using System.Collections;

public class AbilityButtons : MonoBehaviour {

    private Cooldowns _cooldownManager;
    private Player _playerScript;
    private Sounds _sounds;
    private CameraShake _cameraShakeScript;

    [SerializeField]private GameObject _parentObject;
    [SerializeField]private GameObject _laserbeamParent;
    [SerializeField]private GameObject _swordHitbox;
    private AudioSource source;

    private float _laserCooldown = 0;
    private float _medusaCooldown = 0;
    private float _swordCooldown = 0;
    private float _minCooldown = 0;

    private delegate void SoundDelegate(AudioClip clip);

    private SoundDelegate soundDelegate;

    private void Start()
    {
        _cameraShakeScript = GameObject.FindWithTag(Tags.MainCameraTag).GetComponent<CameraShake>();
        soundDelegate = playSound;
        _sounds = GameObject.FindWithTag("SoundsObject").GetComponent<Sounds>();
        source = _sounds.GetComponent<AudioSource>();
        _playerScript = GetComponentInParent<Player>();
        _cooldownManager = GetComponentInParent<Cooldowns>();
        this.gameObject.tag = Tags.AbilityButtonsTag;
    }

    private void Update()
    {
        ResetCooldowns();
    }

    public void UseSword(float SwordCD)
    {
        if (_playerScript.UsingSword == false && _swordCooldown <= _minCooldown) 
        {
            _playerScript.UsingSword = true;
            StartCoroutine(ActivateTimer(_swordHitbox, 1.75f));
            _swordCooldown = SwordCD;
            _cooldownManager.SwordCooldown = _swordCooldown;
            soundDelegate(_sounds.SwordSound);
            StartCoroutine(SetAnimationBool(_playerScript.UsingMedusaHead, 2f));
        }
    }

    public void UseLaser(float LaserCD)
    {
        if (_laserCooldown <= _minCooldown)
        {
            _playerScript.UsingLaser = true;
            _laserCooldown = LaserCD;
            _cooldownManager.LaserCooldown = _laserCooldown;
            StartCoroutine(AbilityDelay(1f, "Laser"));
            StartCoroutine(SetAnimationBool(_playerScript.UsingMedusaHead, 1.5f));
        }
    }

    public void UseMedusaHead(float MedusaCD)
    {
        if (_medusaCooldown <= _minCooldown)
        {
            _playerScript.UsingMedusaHead = true;
            _medusaCooldown = MedusaCD;
            _cooldownManager.MedusaCooldown = _medusaCooldown;
            StartCoroutine(AbilityDelay(1f, "MedusaHead"));
            StartCoroutine(SetAnimationBool(_playerScript.UsingMedusaHead, 2f));
        }
    }

    private void playSound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

    private IEnumerator ActivateTimer(GameObject obj, float activeTime)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(activeTime);
        obj.SetActive(false);
    }

    private IEnumerator SetAnimationBool(bool isUsingItem, float itemCooldown)
    {
        yield return new WaitForSeconds(itemCooldown);
        isUsingItem = false;
    }

    private IEnumerator AbilityDelay(float delay, string whichAbility)
    {
        yield return new WaitForSeconds(delay);
        
        if(whichAbility == "MedusaHead")
        {
            GameObject shockwave = ObjectPool.instance.GetObjectForType(ObjectNames.MedusaEffectGameObjectName, true);
            shockwave.transform.parent = _parentObject.transform;
            shockwave.transform.position = _parentObject.transform.position;
            soundDelegate(_sounds.MedusaSound);
            StartCoroutine(ActivateTimer(_parentObject, 1f));
        }

        else if(whichAbility == "Laser")
        {
            GameObject laserbeam = ObjectPool.instance.GetObjectForType(ObjectNames.LaserBeamName, true);
            laserbeam.transform.parent = _laserbeamParent.transform;
            laserbeam.transform.position = _laserbeamParent.transform.position;
            _cameraShakeScript.Shake();
            soundDelegate(_sounds.LaserSound);
            StartCoroutine(ActivateTimer(_laserbeamParent, 1.5f));
        }
        
    }

    public void ResetCooldowns()
    {
        if(_cooldownManager.MedusaCooldown <= _minCooldown)
        {
            _medusaCooldown = _cooldownManager.MedusaCooldown;
        }
        if (_cooldownManager.LaserCooldown <= _minCooldown) 
        {
            _laserCooldown = _cooldownManager.LaserCooldown;
        }
        if (_cooldownManager.SwordCooldown <= _minCooldown)
        {
            _swordCooldown = _cooldownManager.SwordCooldown;
        }
    }
}
