using UnityEngine;
using System.Collections;

public class DestroyObjectOverTime : MonoBehaviour {

    [SerializeField]private float _destroyTime;
    private ObjectPool _objectPoolScript;

    private void Start () 
    {
        _objectPoolScript = GameObject.FindWithTag(Tags.ObjectPoolTag).GetComponent<ObjectPool>();
	}

    private void OnEnable()
    {
        StartCoroutine(DestroyTheObject());
    }

    private IEnumerator DestroyTheObject()
    {
        yield return new WaitForSeconds(_destroyTime);
        _objectPoolScript.PoolObject(this.gameObject);
    }
}
