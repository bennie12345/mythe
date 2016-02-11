using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
    private bool _isShaking = false;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        CheckForShake();
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
            this.gameObject.transform.position = new Vector3(Random.Range(17f, 18f), Random.Range(-14.5f, -15.5f), -59.7f);
        }
        else
        {
            this.gameObject.transform.position = new Vector3(17.3f, -15, -59.7f);
        }
    }

    IEnumerator CameraShaking()
    {
        yield return new WaitForSeconds(0.5f);
        _isShaking = false;
    }

    //use this to shake the camera: GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake();
}
