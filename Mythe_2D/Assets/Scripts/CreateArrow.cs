using UnityEngine;
using System.Collections;

public class CreateArrow : MonoBehaviour {

    [SerializeField]private Transform arrow;
    public float cooldown;
    private float minCooldown = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Cooldown();
	}

    public void Shoot()
    {
        if(cooldown <= minCooldown)
        {
            Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, -90));
            SetCooldown(1f);
        }
    }

    private void Cooldown()
    {
        if (cooldown >= minCooldown)
        {
            cooldown -= Time.deltaTime;
        }
    }

    private void SetCooldown(float setCooldown)
    {
        cooldown = setCooldown;
    }
}
