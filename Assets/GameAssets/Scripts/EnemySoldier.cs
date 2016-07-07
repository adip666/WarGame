using UnityEngine;
using System.Collections;

public class EnemySoldier : MonoBehaviour {
    public bool isDeath, isFire, isDestroy, Patrol;
    public float fireRate;
    public GameObject Bolt, BloodFX;
    public Transform ShotSpawn;
    public int Type;
    public Transform StartMove, EndMove;

    NavMeshAgent Agent;
    int AmmoValue = 7, ValueDeath;
    float nextFire;
    Animator animator;
    bool readyToShoot;
    bool isEnd;
    // Use this for initialization
    void Awake () {
        animator = GetComponentInChildren<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        
        
    }
    void Start()
    {
        if (Type == 1)
        {
          StartMove = GameObject.Find("StartSoldier1").GetComponent<Transform>();
          EndMove =  GameObject.Find("endSoldier1").GetComponent<Transform>();
        }
        if (Type == 2)
        {
            StartMove = GameObject.Find("StartSoldier2").GetComponent<Transform>();
            EndMove = GameObject.Find("endSoldier2").GetComponent<Transform>();
        }
    }
    

    // Update is called once per frame
    void Update () {

        if (isDeath)
        {
            if (ValueDeath == 0)
            {
                ValueDeath++;
                Death();
            }
        }
        else
        {
            Walk();
            CheckPosition();
            Shoot();
        }
	}
   public void Death()
    {
 
        animator.SetBool("Death_b", true);
        Instantiate(BloodFX, transform.position, transform.rotation);
        
        if (isDestroy)
        {
            StartCoroutine("Destroyer");
        }

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
        AmmoValue = 7;

    }
    IEnumerator Crouch()
    {
        
            animator.SetBool("Crouch_b", true);
            yield return new WaitForSeconds(1.5f);
            readyToShoot = true;
            
        

    }
    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Player" || coll.tag == "Zombie")
        {
            isFire = true;
            transform.LookAt(coll.transform);
        }

    }
    void OnTriggerExit()
    {
        
        isFire = false;

    }
    public void Walk()
    {
        if (!isFire)
        {
            Agent.Resume();
            if (!isEnd)
            {
                Agent.SetDestination(EndMove.position);

            }
            else
            {
                if (Patrol)
                {
                    Agent.SetDestination(StartMove.position);
                }
                else
                {
                       Destroy(gameObject);
                }

            }
        }
        else
        {
            Agent.Stop();
        }
    }
    void CheckPosition()
    {
        
        if (transform.position.z == EndMove.position.z && transform.position.x == EndMove.position.x)
        {
            isEnd = true;
        }
        else if (transform.position.z == StartMove.position.z && transform.position.x == StartMove.position.x)
        {
            isEnd = false;
        }
    }
    IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    
}
