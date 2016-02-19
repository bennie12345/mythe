using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderCooldown : MonoBehaviour {

    private Cooldowns _coolDownScript;

    [SerializeField]private Image _medusaSlider;
    [SerializeField]private Image _swordSlider;
    [SerializeField]private Image _laserSlider;

    private float _medusaOffset = 10;
    private float _swordOffset = 5;
    private float _laserOffset = 20;

	// Use this for initialization
	void Start () 
    {
        _coolDownScript = GameObject.FindWithTag(Tags.playerTag).GetComponent<Cooldowns>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        _medusaSlider.fillAmount = _coolDownScript.MedusaCooldown / _medusaOffset;
        _swordSlider.fillAmount = _coolDownScript.SwordCooldown / _swordOffset;
        _laserSlider.fillAmount = _coolDownScript.LaserCooldown / _laserOffset;
    }
}