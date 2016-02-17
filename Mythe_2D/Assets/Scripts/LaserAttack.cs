using UnityEngine;
using System.Collections;

public class LaserAttack : MonoBehaviour {
    public float cooldown;
    private float minCooldown = 0;
    private GameObject Laserbeam;
	

	// Use this for initialization
	void Start () {
        Laserbeam = GameObject.FindWithTag("Laser");
        


	}
   public void Laser() 
    {
        if (cooldown <= minCooldown)
        {
            StartCoroutine(ActivateTimer());
            SetCooldown(10f);
            
        }
    }
	
    IEnumerator ActivateTimer()
    {
        Laserbeam.SetActive(true);
        yield return new WaitForSeconds(2);
        Laserbeam.SetActive(false);



    }
	// Update is called once per frame
	void Update () {
        Cooldown();
	
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
