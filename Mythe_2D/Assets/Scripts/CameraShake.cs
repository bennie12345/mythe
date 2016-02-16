using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
    private bool _isShaking = false;

    private float _shakeDuration = 0.25f;
    private float _originalXPos = 0f;
    private float _originalYPos = 0f;
    private float _offsetXPos; //set to _originalXpos +/- 0.5f/1f
    private float _offsetYPos; //set to _originalYPos +/- 0.5f/1f

	// Use this for initialization
	void Start () 
    {
        _offsetXPos = _originalXPos + 0.5f;
        _offsetYPos = _originalXPos - 0.5f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public void Shake()
    {
        _isShaking = true;
        StartCoroutine(CameraShaking());
    }

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

    IEnumerator CameraShaking()
    {
        yield return new WaitForSeconds(_shakeDuration);
        _isShaking = false;
    }

    //use this to shake the camera: GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake();
}
