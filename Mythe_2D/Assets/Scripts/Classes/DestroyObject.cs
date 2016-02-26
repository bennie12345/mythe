using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    [SerializeField]private float _destroyTime;
    private ObjectPool _objectPoolScript;

	void Start () 
    {
        _objectPoolScript = GameObject.FindWithTag(Tags.objectPoolTag).GetComponent<ObjectPool>();
	}

    void OnEnable()
    {
        StartCoroutine(DestroyTheObject());
    }

    IEnumerator DestroyTheObject()
    {
        yield return new WaitForSeconds(_destroyTime);
        _objectPoolScript.PoolObject(this.gameObject);
    }
}
