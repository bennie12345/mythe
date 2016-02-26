using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    [SerializeField]private float _destroyTime;
    private ObjectPool _objectPoolScript;
    private bool _canPutBack = false;

	void Start () 
    {
        _objectPoolScript = GameObject.FindWithTag(Tags.objectPoolTag).GetComponent<ObjectPool>();
	}

    void Update()
    {
        if (!_canPutBack)
        {
            StartCoroutine(DestroyTheObject());
        }
    }

    IEnumerator DestroyTheObject()
    {
        _canPutBack = true;
        yield return new WaitForSeconds(_destroyTime);
        _objectPoolScript.PoolObject(this.gameObject);
        _canPutBack = false;
    }
}
