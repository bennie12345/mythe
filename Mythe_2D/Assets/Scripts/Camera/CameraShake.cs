using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    //makes the camera shake when the player is hit or the player kills something
    private bool _isShaking = false;

    private float _shakeDuration = 0.25f;
    private float _originalXPos = 0f;
    private float _originalYPos = 0f;
    private float _shakeIntensity = 0.5f;
    private float _offsetXPos; //set to _originalXpos +/- _shakeIntensity
    private float _offsetYPos; //set to _originalYPos +/- _shakeIntensity

	// Use this for initialization
    private void Start () 
    {
        this.gameObject.tag = Tags.MainCameraTag;
        _offsetXPos = _originalXPos + _shakeIntensity;
        _offsetYPos = _originalXPos - _shakeIntensity;
	}
	
	// Update is called once per frame
    private void Update () 
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
    private void CheckForShake()
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
    private IEnumerator CameraShaking()
    {
        yield return new WaitForSeconds(_shakeDuration);
        _isShaking = false;
    }

}
