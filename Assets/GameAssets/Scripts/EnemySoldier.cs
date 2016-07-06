using UnityEngine;
using System.Collections;

public class EnemySoldier : MonoBehaviour {
    public bool isDeath, isFire;
    public float fireRate;
    public GameObject Bolt;
    public Transform ShotSpawn;

    int AmmoValue = 15;
    float nextFire;
    Animator animator;
   public bool readyToShoot;
    // Use this for initialization
    void Awake () {
        animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Shoot();
        if (isDeath)
        {
            Death();
        }
	}
   public void Death()
    {
        animator.SetBool("Death_b", true);
    }

    public void Shoot()
    {
        if (isFire)
        {
            StartCoroutine("Crouch");
        }

        if (isFire && readyToShoot && Time.time > nextFire && AmmoValue>0)
        {
            animator.SetBool("Shoot_b", true);
            nextFire = Time.time + fireRate;
            Instantiate(Bolt, ShotSpawn.position, ShotSpawn.rotation);
            AmmoValue--;
            
        }
        else if (AmmoValue == 0)
        {
            StartCoroutine("ReloadGun");
        }
        if (!isFire)
        {
            animator.SetBool("Shoot_b", false);
            animator.SetBool("Crouch_b", false);
            readyToShoot = false;

        }



    }
    IEnumerator ReloadGun()
    {
        animator.SetBool("Reload_b", true);
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("Reload_b", false);
        AmmoValue = 15;

    }
    IEnumerator Crouch()
    {
        
            animator.SetBool("Crouch_b", true);
            yield return new WaitForSeconds(1.5f);
            readyToShoot = true;
            
        

    }
    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Player")
        {
            isFire = true;
            
        }

    }
    void OnTriggerExit()
    {
        
        isFire = false;

    }
}
