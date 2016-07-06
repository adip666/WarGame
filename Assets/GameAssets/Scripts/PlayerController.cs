using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {
    public float speed;
    public GameObject Bolt;
    public Transform ShotSpawn;
    public int Ammo;
    public Text InfoAmmo;
	// Use this for initialization
	
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
}
