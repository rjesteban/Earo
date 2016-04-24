using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RiseElevator : MonoBehaviour {

	public static RiseElevator instance{get; private set;}
	public bool touch;
	public Image jump;

	void Awake(){
		instance = this;
	}

	public Animator anim;
	public float time;
	// Use this for initialization
	void Start () {
		touch = false;
		anim = gameObject.GetComponent<Animator> ();
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay2D(Collider2D collider){
		if (collider.transform.tag=="Player") {
			touch = true;
			Debug.Log("bangga");
			if (EaroScript.isRising){
				EaroStatus.instance.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,gameObject.transform.position.z);
				anim.SetBool("moveup",true);
				anim.SetFloat("Time", time);
				time+=Time.deltaTime;

				jump.enabled = false;

				HeadCollision.instance.gameObject.GetComponent<Collider2D>().isTrigger = true;
				ArmCollision.instance.gameObject.GetComponent<Collider2D>().isTrigger = true;
				FeetCollision.instance.gameObject.GetComponent<Collider2D>().isTrigger = true;
				FeetCollision.instance.GetComponent<Rigidbody2D>().isKinematic = true;


				if(time > 20.0f){
					anim.SetBool("moveup", false);
					jump.enabled = true;
					HeadCollision.instance.gameObject.GetComponent<Collider2D>().isTrigger = false;
					ArmCollision.instance.gameObject.GetComponent<Collider2D>().isTrigger = false;
					FeetCollision.instance.gameObject.GetComponent<Collider2D>().isTrigger = false;
					FeetCollision.instance.GetComponent<Rigidbody2D>().isKinematic = false;
				}
			}
		}
	}
	

}
