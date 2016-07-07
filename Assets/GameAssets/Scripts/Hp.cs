using UnityEngine;
using System.Collections;

public class Hp : MonoBehaviour {
    PlayerController Controler;

    public int ValueHP;
    public float speed;
    // Use this for initialization
    void Awake () {
        Controler = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

    }

    void Update()
    {
        transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            Debug.Log("KOLIZJA");
            Controler.HP += ValueHP;
            Destroy(gameObject);
        }
    }
}
