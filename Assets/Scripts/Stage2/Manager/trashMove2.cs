using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class trashMove2 : MonoBehaviour {
//	private Transform fallingTrash;

	public Rigidbody2D trash;
	public Animator anim;
	public int random_Kind;
	public bool isWrong;
	public int random_Sprite;
//	public SpriteRenderer storeThisAnimation;

	//public GameObject parent;

	void Start () {
		random_Kind = 0;

		trash = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		random_Sprite = Random.Range(0,12);
		isWrong = false;
//		anim.SetBool("isWrong", isWrong);
		anim.SetInteger ("random_Kind", random_Kind);
		anim.SetInteger ("random_Sprite", random_Sprite);
		anim.SetBool("changeSprite", true);


	}

	void FixedUpdate(){
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		trash.velocity = new Vector2 (trash.velocity.x, 0.8f );
//		anim.SetBool("isWrong",true);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.transform.tag == "limit"){
			Destroy(gameObject);
		}
	}
}

	
