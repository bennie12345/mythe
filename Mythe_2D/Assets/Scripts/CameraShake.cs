using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
    private bool _isShaking = false;

    private float _shakeDuration = 0.25f;
    private float _originalXPos = 0f;
    private float _originalYPos = 0f;
    private float _shakeIntensity = 0.5f;
    private float _offsetXPos; //set to _originalXpos +/- _shakeIntensity
    private float _offsetYPos; //set to _originalYPos +/- _shakeIntensity

	// Use this for initialization
	void Start () 
    {
        _offsetXPos = _originalXPos + _shakeIntensity;
        _offsetYPos = _originalXPos - _shakeIntensity;
	}
	
	// Update is called once per frame
	void Update () 
    {
        CheckForShake();
	}

    //start duration of the shake and shake itself
    public void Shake()
    {
        _isShaking = true;
        StartCoroutine(CameraShaking());
    }

    //check if camera should be shaking, if yes, starts shaking
    void CheckForShake()
    {
        if (_isShaking)
        {
            this.gameObject.transform.position = new Vector2(Random.Range(_originalXPos, _offsetXPos), Random.Range(_originalYPos, _offsetYPos));
        }
        else
        {
            this.gameObject.transform.position = new Vector2(_originalXPos , _originalYPos);
        }
    }

    //duration of the shake
    IEnumerator CameraShaking()
    {
        yield return new WaitForSeconds(_shakeDuration);
        _isShaking = false;
    }

}
