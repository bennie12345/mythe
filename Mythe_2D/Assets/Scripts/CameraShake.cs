using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
    private bool _isShaking = false;

    private float _shakeDuration = 0.25f;

	// Use this for initialization
	void Start () 
    {
	
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
            this.gameObject.transform.position = new Vector2(Random.Range(0f, 0.5f), Random.Range(0f, -0.5f));
        }
        else
        {
            this.gameObject.transform.position = new Vector2(0f , 0f);
        }
    }

    IEnumerator CameraShaking()
    {
        yield return new WaitForSeconds(_shakeDuration);
        _isShaking = false;
    }

    //use this to shake the camera: GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake();
}
