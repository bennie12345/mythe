using UnityEngine;
using System.Collections;

public class CreateArrow : MonoBehaviour {

    [SerializeField]private Transform arrow;
    public float cooldown;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Cooldown();
	}

    public void Shoot()
    {
        if(cooldown <= 0)
        {
            Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, -90));
            cooldown = 1;
        }
    }

    private void Cooldown()
    {
        if (cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        }
    }
}
