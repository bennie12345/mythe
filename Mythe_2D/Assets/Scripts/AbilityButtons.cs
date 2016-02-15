using UnityEngine;
using System.Collections;

public class AbilityButtons : MonoBehaviour {

    private Player _playerScript;

    void Start()
    {
        _playerScript = new Player();
    }

    public void UseSword()
    {
        if (_playerScript.UsingSword == false) 
        {
            _playerScript.UsingSword = true;
        }
    }

}
