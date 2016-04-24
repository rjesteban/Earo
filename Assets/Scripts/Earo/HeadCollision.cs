using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeadCollision : MonoBehaviour {

	public static HeadCollision instance{get; private set;}
	
	void Awake(){
		instance = this;
	}


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		float mass = collision.gameObject.GetComponent<Rigidbody2D>().mass;
		float velocitysquared = collision.relativeVelocity.magnitude*collision.relativeVelocity.magnitude;
		float KE = 0.5f*mass*velocitysquared;
		Debug.Log("HEADSHOT! by: " + collision.gameObject.transform.tag + " " +  mass*velocitysquared);

		if(collision.gameObject.GetComponent<Rigidbody2D>().isKinematic == false){
			if((collision.gameObject.transform.tag == "Bruiser" && KE>500.0f) ||
			   (collision.gameObject.transform.tag == "Sharpee" && KE>15.0f))
				EaroStatus.isAlive = false;
			else if(collision.gameObject.transform.tag == "Bruiser" && KE>7.0f){
				EaroStatus.isBruised = true;
			}
			else if(collision.gameObject.transform.tag == "Sharpee" && KE>3.0f)
				EaroStatus.isCut = true;
		}

	}

	void OnTriggerStay2D(Collider2D collider){
		if (collider.transform.tag == "Electric" && TriggerFallPost.canElectricute) {
			EaroStatus.isAlive = false;

		}
	}
}

	
