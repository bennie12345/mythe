using UnityEngine;
using System.Collections;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 beginPosition;
    private Vector3 newPosition;
    private Renderer renderer;
    public Camera camera;
    private Vector3 worldedge;
	
    // Use this for initialization
	void Start ()
    {
        beginPosition = transform.position;
        newPosition = beginPosition;
        renderer = GetComponent<Renderer>();
        Vector3 distance = camera.transform.position - transform.position;
        worldedge = camera.ScreenToWorldPoint(new Vector3(0, 0, distance.z));
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 offset = new Vector3(Time.time * speed, 0,0);
        newPosition.x -= Time.deltaTime * speed; //object is scrolling
        transform.position = newPosition;
        renderer.material.mainTextureOffset = offset;

        float width = renderer.bounds.size.x;
       
        //when the object will spawn
        if (newPosition.x < worldedge.x - width/2)
        {
            Vector3 newpos = transform.position;
            newpos.x += width * 2; //the width of the object
            transform.position = newPosition = newpos;
        }
	}
}
