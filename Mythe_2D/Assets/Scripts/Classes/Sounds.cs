using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

    private AudioSource _source;
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

	// Use this for initialization
	void Start () {
        this.gameObject.tag = Tags.soundsObjectTag;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
