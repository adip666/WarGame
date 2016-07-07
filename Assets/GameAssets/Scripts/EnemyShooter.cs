using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {
    public GameObject Bolt;
    public Transform ShotSpawn;
    public float fireRate;

    Transform target;
    bool Fire;
    float nextFire;

    // Use this for initialization
    void Awake () {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        if (Fire && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Bolt, ShotSpawn.position, ShotSpawn.rotation);
        }
	}
    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Player")
        {
            // Destroy(gameObject);
            Fire = true;
            
        }
    
    }
    void OnTriggerExit()
    {
        Fire = false;
    }
}
