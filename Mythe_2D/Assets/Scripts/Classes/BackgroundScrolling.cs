using UnityEngine;
using System.Collections;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField]private float _speed = 0.5f;
    private Vector3 _beginPosition;
    private Vector3 _newPosition;
    private Renderer _renderer;
    [SerializeField]private Camera _camera;
    private Vector3 _worldedge;
	// Use this for initialization
	void Start ()
    {
        _beginPosition = transform.position;
        _newPosition = _beginPosition;
        _renderer = GetComponent<Renderer>();
        Vector3 distance = _camera.transform.position - transform.position;
        _worldedge = _camera.ScreenToWorldPoint(new Vector3(0, 0, distance.z));
	}
	
	// Update is called once per frame
	void Update ()
    {
        _newPosition.x -= Time.deltaTime * _speed;
        transform.position = _newPosition;
       

        float width = _renderer.bounds.size.x;

        if (_newPosition.x < _worldedge.x - width/2)
        {
            Vector2 newpos = transform.position;
            newpos.x += width*2;
            transform.position = _newPosition = newpos;
        }
	}
}
