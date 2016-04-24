using UnityEngine;
using System.Collections;

public class ArmCollision : MonoBehaviour {

	public static ArmCollision instance{get; private set;}

	void Awake(){
		instance = this;
	}

	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		float mass = collision.gameObject.GetComponent<Rigidbody2D>().mass;
		float velocitysquared = collision.relativeVelocity.magnitude*collision.relativeVelocity.magnitude;
		float KE = 0.5f*mass*velocitysquared;

		if(collision.gameObject.transform.tag == "Bruiser" && KE>7.0f)
			EaroStatus.isBruised = true;
		else if(collision.gameObject.transform.tag == "Sharpee" && KE>3.0f)
			EaroStatus.isCut = true;
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
