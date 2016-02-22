using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    [SerializeField]private float destroyTime;

	void Start () 
    {
        DestroyTheObject();
	}

    void DestroyTheObject()
    {
        Destroy(this.gameObject, destroyTime);
    }
}
