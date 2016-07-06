using UnityEngine;
using System.Collections;

public class ZombiesControll : MonoBehaviour {
    public Transform Start, End;
    NavMeshAgent Agent;
    
    public bool isEnd;
	void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
	void Update () {
        
        Walk();
        CheckPosition();
        
       
	}
    public void Walk()
    {
        if (!isEnd)
        {
            Agent.SetDestination(End.position);
            
        }
        else
        {
            Agent.SetDestination(Start.position);
            
        }
    }
    void CheckPosition()
    {
        
        if (transform.position.z == End.position.z && transform.position.x == End.position.x)
        {
            isEnd = true;
        }
        else if(transform.position.z == Start.position.z && transform.position.x == Start.position.x)
        {
            isEnd = false;
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player"|| coll.tag == "Ammo")
        {
            Destroy(gameObject);
        }
    }
}
