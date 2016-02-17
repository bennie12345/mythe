using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    [SerializeField]private float destroyTime;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, destroyTime);
	}
}
