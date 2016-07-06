using UnityEngine;
using System.Collections;

public class DoubleTapMe : MonoBehaviour {
    PlayerController controll;
    void Awake()
    {
        controll = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
	// Subscribe to events
	void OnEnable(){
		EasyTouch.On_DoubleTap += On_DoubleTap;	
	}

	void OnDisable(){
		UnsubscribeEvent();
	}
	
	void OnDestroy(){
		UnsubscribeEvent();
	}
	
	void UnsubscribeEvent(){
		EasyTouch.On_DoubleTap -= On_DoubleTap;	
	}	
	
	// Double tap  
	private void On_DoubleTap( Gesture gesture){
        controll.Shot();
        // Verification that the action on the object
        /*if (gesture.pickedObject == gameObject){
            
            gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }*/
    }
}
