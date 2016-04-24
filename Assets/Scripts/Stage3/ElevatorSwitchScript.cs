using UnityEngine;
using System.Collections;

public class ElevatorSwitchScript : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.name == "Earokunuhay") {
			if (EaroScript.isRising) {
				anim.SetBool("isItOn",true);
			}
			//else{
			//	anim.SetBool("isItOn",true);
			//}
		}
	}
	void OnTriggerStay2D(Collider2D collider){
		if (collider.name == "Earokunuhay") {
				anim.SetBool("isItOn",true);
		}

	}

	void OnTriggerExit2D(Collider2D collider){
		if (collider.name == "Earokunuhay") {
			//if (EaroScript.isRising) 
				anim.SetBool("isItOn",false);
		}
	}

}
