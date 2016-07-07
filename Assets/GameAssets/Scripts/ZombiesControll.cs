using UnityEngine;
using System.Collections;

public class ZombiesControll : MonoBehaviour {
    public bool isEat;
    public GameObject BloodFX;
    public string type;
    
    bool isEnd;
    public NavMeshAgent Agent;
    Animator animator;
    public Transform StartMove, EndMove;

    void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

    }
    void Start()
    {
        if(type == "Blue")
        {
            StartMove = GameObject.Find("StartZombieBlue").GetComponent<Transform>();
            EndMove = GameObject.Find("EndZombieBlue").GetComponent<Transform>();

        }
        if (type == "Grey")
        {
            StartMove = GameObject.Find("StartZombieGrey").GetComponent<Transform>();
            EndMove = GameObject.Find("endZombieGrey").GetComponent<Transform>();

        }
        if (type == "Green")
        {
            StartMove = GameObject.Find("StartZombieGreen").GetComponent<Transform>();
            EndMove = GameObject.Find("EndZombieGreen").GetComponent<Transform>();

        }
    }
	void Update () {

        if (isEat)
        {
            animator.SetBool("Eat", true);

        }
        else
        {
            Walk();
            CheckPosition();
        }


    }
    public void Walk()
    {
        if (!isEnd)
        {
            Agent.SetDestination(EndMove.position);
            
        }
        else
        {
            Agent.SetDestination(StartMove.position);
            
        }
    }
    void CheckPosition()
    {
        
        if (transform.position.z == EndMove.position.z && transform.position.x == EndMove.position.x)
        {
            isEnd = true;
        }
        else if(transform.position.z == StartMove.position.z && transform.position.x == StartMove.position.x)
        {
            isEnd = false;
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player"|| coll.tag == "Ammo" || coll.tag == "AmmoEnemy")
        {
            Destroy(gameObject);
            Instantiate(BloodFX, transform.position, transform.rotation);
            if(coll.tag == "Ammo"|| coll.tag == "AmmoEnemy") {
                Destroy(coll.gameObject);
            }
        }
    }
}
