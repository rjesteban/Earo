using UnityEngine;
using System.Collections;

public class SurvivorMove : MonoBehaviour {
//	private Transform fallingTrash;
	private Rigidbody2D survivor;
	private Animator anim;
	public int random_Kind;
	public int random_Sprite;
//public SpriteRenderer storeThisAnimation;
	
	//public GameObject parent;
	
	void Start () {
		survivor= GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		random_Kind = 1;
		random_Sprite = Random.Range(0,4);
		Debug.Log ( "kind:" + random_Kind);
		Debug.Log ( "Sprite:" + random_Sprite);


		anim.SetInteger ("random_Kind", random_Kind);
		anim.SetInteger ("random_Sprite", random_Sprite);
		anim.SetBool("changeSprite", true);
	}
	
	void FixedUpdate(){
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		survivor.velocity = new Vector2 (survivor.velocity.x, 0.8f );
//		anim.SetBool ("changeSprite", false);
		//if (RandomNow) {
//		anim.SetBool ("changeSprite", true); 		
	}

	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.transform.tag == "limit"){
			LifeSaver.m_lives--;
			if(LifeSaver.m_lives == 0)
				GameManager2.instance.isMissionFailed();
			Destroy(gameObject);
		}
	}
}
