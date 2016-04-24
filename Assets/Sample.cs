using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sample : MonoBehaviour {

	public Vector2 velocity;

	// Use this for initialization
	void Start () {
		velocity = new Vector2 (0, 0);;
	}




	// Update is called once per frame
	void Update () {

		if(Time.frameCount%5==0){
			velocity  = gameObject.GetComponent<Rigidbody2D> ().velocity;
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log("shooow: " + velocity);

		// the dot product of collision normal and collision velocity
		//(ie the velocity of the two bodies relative to each other), 
		//times the mass of the other collider should give you useful values.
		foreach (ContactPoint2D contact in collision.contacts) {
			float impactVelocityX = velocity.x - contact.otherCollider.GetComponent<Rigidbody2D> ().velocity.x;
			impactVelocityX *= Mathf.Sign (impactVelocityX);
			float impactVelocityY = velocity.y - contact.otherCollider.GetComponent<Rigidbody2D> ().velocity.y;
			impactVelocityY *= Mathf.Sign (impactVelocityY);
			
			float x = contact.normal.x * impactVelocityX * contact.otherCollider.GetComponent<Rigidbody2D>().mass;
			Debug.Log(x + " is the float x");
			float y = contact.normal.y * impactVelocityY * contact.otherCollider.GetComponent<Rigidbody2D>().mass;
			Debug.Log(y + " is the float y");
			float impulse = Mathf.Sqrt((x*x)+(y*y));
			Debug.Log(impulse + " is the impulsessss");
		}

	}
	

	public void _restart(){
		Application.LoadLevel ("Stage1");
	}
	

}
