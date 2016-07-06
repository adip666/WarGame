using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    public GameObject ExplosionFX;
    // Use this for initialization
    void Start () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player" || coll.tag == "Ammo")
        {
            Destroy(gameObject);
            Instantiate(ExplosionFX, transform.position, transform.rotation);
        }
    }
}
