using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Update() {
         GetComponent<Rigidbody>().velocity = transform.up * speed;
        StartCoroutine("Destroyer");
       // transform.localPosition = new Vector3(0, 0, speed * Time.deltaTime);
    }
IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
	


}
