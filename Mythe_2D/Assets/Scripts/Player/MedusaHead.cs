using UnityEngine;
using System.Collections;

public class MedusaHead : MonoBehaviour {

    [SerializeField]private GameObject effectCollider;
    [SerializeField]private ParticleSystem particles;
    [SerializeField]private Transform parentObject;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        OnMouseDown();
	}

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ParticleSystem instantiatedObject = Instantiate(particles, transform.position, Quaternion.Euler(0, 90, -90)) as ParticleSystem;
            instantiatedObject.transform.parent = parentObject;
            Instantiate(effectCollider);
         }
    }
}
