using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderCooldown : MonoBehaviour {

    private AbilityButtons abilities;

    private Slider cooldownSlider;
	// Use this for initialization
	void Start () {
        cooldownSlider = GetComponent<Slider>();
        abilities = GameObject.FindGameObjectWithTag(Tags.abilityButtonsTag).GetComponent<AbilityButtons>();
	}
	
	// Update is called once per frame
	void Update () {
        //cooldownSlider.value = arrow.cooldown;
    }
}
