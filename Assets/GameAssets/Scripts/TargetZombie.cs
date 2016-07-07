using UnityEngine;
using System.Collections;

public class TargetZombie : MonoBehaviour {

    public GameObject Zombie;
    ZombiesControll controll;
	// Use this for initialization
	void Awake () {
        controll = Zombie.GetComponent<ZombiesControll>();
	}
	
	// Update is called once per frame
	void OnTriggerStay(Collider coll)
    {
       if( coll.tag == "Player")
        {
            controll.Agent.SetDestination(coll.transform.position);
            Debug.Log("kolizja");
        }
    }
}
