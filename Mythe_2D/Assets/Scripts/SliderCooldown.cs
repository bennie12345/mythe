using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderCooldown : MonoBehaviour {

    CreateArrow arrow;

    private Slider cooldownSlider;
	// Use this for initialization
	void Start () {
        cooldownSlider = GetComponent<Slider>();
        arrow = GameObject.FindGameObjectWithTag("Player").GetComponent<CreateArrow>();
	}
	
	// Update is called once per frame
	void Update () {
        cooldownSlider.value = arrow.cooldown;
    }
}
