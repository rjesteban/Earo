using UnityEngine;
using System.Collections;

public class TriggerFallPost : MonoBehaviour {

	public GameObject _toFall;
	public GameObject _transformer;
	public bool falling = false;
	public Animator anim;
	public static bool canElectricute = false;

	// Use this for initialization
	void Start () {
		anim = _transformer.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Player") {
			_toFall.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
			gameObject.GetComponent<Collider2D> ().enabled = false;
			falling = true;
			StartCoroutine(explodeTransformer());
		}
	}

	IEnumerator explodeTransformer(){
		while (EaroStatus.isAlive) {
			if (falling) {
				yield return new WaitForSeconds (5.0f);
				_toFall.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
				Collider2D[] colliders = _toFall.gameObject.GetComponents<Collider2D> ();
				foreach (Collider2D col in colliders)
					col.isTrigger = true;
				anim.SetBool ("ToBlast", true);
				falling = false;
			} else {
				yield return new WaitForSeconds (3.0f);
				anim.SetBool ("ToBlast", !anim.GetBool ("ToBlast"));
			}
			canElectricute = anim.GetBool("ToBlast");
		}
	}

}
