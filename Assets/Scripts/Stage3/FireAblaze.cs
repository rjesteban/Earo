using UnityEngine;
using System.Collections;

public class FireAblaze : MonoBehaviour {
	
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.transform.tag == "Player")
			anim.SetBool("Ignition", true);
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.transform.tag == "Player"){
			int random = Random.Range(0,2);
			if(random == 0){
				EaroStatus.isFirstDegBurned = true;
			}
			else if(random == 1){
				EaroStatus.isSecondDegBurned = true;
			}
			else{
				EaroStatus.isThirdDegBurned = true;
			}

		}
	}

	public void turnOffFire(){
		StartCoroutine(startTurnoffFire());
	}

	IEnumerator startTurnoffFire(){
		anim.SetBool("Ignition", false);
		yield return new WaitForSeconds(3.0f);
		Destroy(gameObject);
	}
}
