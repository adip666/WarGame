using UnityEngine;
using System.Collections;

public class Spown : MonoBehaviour {
    public GameObject SpownObject;
    
    public float SpeedSpown;
    public bool isSoldier;

    
    private float nextSpown;
	// Use this for initialization
   
    void Start() {
        
    }
	
	// Update is called once per frame
	void Update () {
        if(Time.time > nextSpown)
        {
            nextSpown = Time.time + SpeedSpown;
            Instantiate(SpownObject, transform.position, transform.rotation);
            

        }
    }
}
