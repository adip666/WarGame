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

    void Awake()
    {
        MainCamera = GameObject.FindWithTag("MainCamera");
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
        if (coll.tag == "Ammo")
        {
            Destroy(coll.gameObject);
            HP -= 10;
            if (HP==0)
            {
                MainCamera.transform.parent=null;
                Destroy(gameObject);
            }

        }
    }
   
}
