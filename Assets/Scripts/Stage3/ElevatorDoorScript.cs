using UnityEngine;
using System.Collections;

public class ElevatorDoorScript : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.transform.tag=="Player") {
			anim.SetBool("isNear",true);
			anim.SetBool("onTheMove",false);
		}
	}
	void OnTriggerStay2D(Collider2D collider){
		if (collider.transform.tag=="Player") {
			if(EaroScript.isRising){
				anim.SetBool("isNear",true);
				anim.SetBool("onTheMove",true);
				Debug.Log("on the move");
			}
		}
	}
	void OnTriggerExit2D(Collider2D collider){
		Debug.Log("basdfas");
		RiseElevator.instance.touch =false;
		if (collider.transform.tag=="Player") {
			anim.SetBool("onTheMove",true);
			anim.SetBool("isNear",false);
		}
	}
}
