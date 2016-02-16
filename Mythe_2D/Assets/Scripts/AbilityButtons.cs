using UnityEngine;
using System.Collections;

public class AbilityButtons : MonoBehaviour {

    private Player _playerScript;
    private GameObject _player;

    void Start()
    {
        _player = GameObject.FindWithTag(Tags.playerTag);
        _playerScript = _player.GetComponent<Player>();
    }

    public void UseSword()
    {
        if (_playerScript.UsingSword == false) 
        {
            _playerScript.UsingSword = true;
        }
    }

}
