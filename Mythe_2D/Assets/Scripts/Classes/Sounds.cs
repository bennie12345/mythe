using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

    [SerializeField]private AudioClip _medusaSound;
    public AudioClip MedusaSound
    {
        get
        {
            return _medusaSound;
        }
        set
        {
            _medusaSound = value;
        }
    }
    [SerializeField]private AudioClip _firingMahLazor;
    public AudioClip FiringMahLazor
    {
        get
        {
            return _firingMahLazor;
        }
        set
        {
            _firingMahLazor = value;
        }
    }

	void Start () {
        this.gameObject.tag = Tags.soundsObjectTag;
	}
}
