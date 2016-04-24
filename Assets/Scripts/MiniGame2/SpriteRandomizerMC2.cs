using UnityEngine;
using System.Collections;

public class SpriteRandomizerMC2 : MonoBehaviour {
	private Animator anim;
	public int randomInt;



	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		randomInt = Random.Range (0, 9);
		randomizeNow ();
	}

	void randomizeNow(){

		anim.SetInteger("whichOne",  randomInt);
		//Debug.Log ("random int " + anim.GetInteger("whichOne"));
		//Debug.Log ("Animator is " + anim);
	}
}
