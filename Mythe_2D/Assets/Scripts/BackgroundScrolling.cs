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
        //Debug.Log("distance" + distance.z);
        //Debug.Log(mesh.bounds);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 offset = new Vector3(Time.time * speed, 0);
        //renderer.material.mainTextureOffset = offset;
        newPosition.x -= Time.deltaTime * speed;
        transform.position = newPosition;
       
        //Debug.Log("np" + newPosition.x);

        float width = renderer.bounds.size.x;
       // Debug.Log("calc" + calc);
        if (newPosition.x < worldedge.x - width/2)
        {
            //Debug.Log("verplaats");
            Vector2 newpos = transform.position;
            newpos.x += width * 2;
            transform.position = newPosition = newpos;
            //Debug.Log("reset");
        }
	}
}
