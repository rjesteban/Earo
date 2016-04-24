using UnityEngine;
using System.Collections;

public class FeetCollision : MonoBehaviour{

	public static FeetCollision instance{get; private set;}
	
	void Awake(){
		instance = this;
	}

	public Vector2 velocity;
	// Use this for initialization
	void Start () {
		velocity = new Vector2 (0, 0);
		velocity  = gameObject.GetComponent<Rigidbody2D> ().velocity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.frameCount%5==0){
			velocity  = gameObject.GetComponent<Rigidbody2D> ().velocity;
		}
	}

	void OnCollisionEnter2D(Collision2D collision){

		float velocitysquared = collision.relativeVelocity.magnitude*collision.relativeVelocity.magnitude;
		float EaroKE = 0.5f*gameObject.GetComponent<Rigidbody2D>().mass*velocitysquared;
		float KE = 0.5f*collision.gameObject.GetComponent<Rigidbody2D>().mass*velocitysquared;
		Debug.Log("1/2mv2 mymass: " + EaroKE);
		Debug.Log("relative velocity " + collision.relativeVelocity.magnitude); 
		if(EaroKE > 1000.0f)
			EaroStatus.isAlive = false;
		else if (EaroKE >600.0f)
			EaroStatus.isSprained = true;

	}
}
