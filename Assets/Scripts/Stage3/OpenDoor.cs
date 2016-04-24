using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D collider){
//		if (collider.name == "Earokunuhay") {
//			if (collisionLeft == true) {
//				anim.SetBool ("toRight", true);
//			} else if (collisionRight == true) {
//				anim.SetBool ("toLeft", true);
//			}
//		}
//	}
}
}
