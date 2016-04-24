using UnityEngine;
using System.Collections;

public class LightCollision : MonoBehaviour {

	bool _on;
	private Animator anim;


	// Use this for initialization
	void Start () {
		_on = true;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!_on) {
			//Debug.Log ("light updated");
//			GetComponent<Light>().enabled = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		anim.SetBool ("Broken", true);
		_on = false;
		//Debug.Log ("collision");
	}
}
