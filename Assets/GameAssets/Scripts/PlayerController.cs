using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {
    public float speed;
    public GameObject Bolt;
    public Transform ShotSpawn;
    public int Ammo;
    public Text InfoAmmo;
    public int HP = 100;

    GameObject MainCamera;
    EnergyBar InfoHP;

    void Awake()
    {
        MainCamera = GameObject.FindWithTag("MainCamera");
        InfoHP = GameObject.Find("Filled Bar").GetComponent<EnergyBar>();
    }
	
   public void Shot()
    {
        if (Ammo > 0)
        {
            Instantiate(Bolt, ShotSpawn.position, ShotSpawn.rotation);
            Ammo--;
        }
    }
   public void turnLeft()
    {
        transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
    }
    void Update()
    {
        InfoAmmo.text = Ammo.ToString();
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "AmmoEnemy")
        {
            Destroy(coll.gameObject);
            HP -= 10;
            InfoHP.SetValueCurrent(HP);
            if (HP==0)
            {
                MainCamera.transform.parent=null;
                Destroy(gameObject);
            }

        }
    }
   
}
