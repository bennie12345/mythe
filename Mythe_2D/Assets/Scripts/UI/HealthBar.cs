using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

    [SerializeField]private Image _healthbar;
    private float _healthbarOffset;
    private Player _playerScript;

	void Start () {
        _playerScript = GameObject.FindWithTag(Tags.playerTag).GetComponent<Player>();
        _healthbarOffset = _playerScript.Health;
	}
	
	void Update () {
        UpdateHealthbar();
	}

    private void UpdateHealthbar()
    {
        _healthbar.fillAmount = _playerScript.Health / _healthbarOffset;
    }
}
