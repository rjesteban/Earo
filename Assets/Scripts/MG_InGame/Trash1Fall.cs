using UnityEngine;
using System.Collections;


public class Trash1Fall : MonoBehaviour {

	private Transform fallingTrash;
	private Rigidbody2D trash;
	private Animator anim;
	public int rightAnswers;
	public int spawnCount;
	public float collisionRadius;
	public Transform trashSpawn;
	public int randomizer_Sprite ;
	public int randomizer_Kind ;
	public Animator binScent;
	public bool RandomNow;
	public SpriteRenderer storeThisAnimation;

	void Start () {
		trash = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		binScent = GameObject.Find ("Bins").GetComponent<Animator> ();
		storeThisAnimation = GetComponent<SpriteRenderer> ();
		fallingTrash = GetComponent<Transform> ();
		rightAnswers = 0;
		spawnCount = 0;
		collisionRadius = 0.6f;
	}

	void FixedUpdate(){
		
	}

	// Update is called once per frame
	void Update () {
		//GameManager.finishInstructions = false;
		Debug.Log (GameManager.finishInstructions);
		if(!binScent.GetBool("isAccomplished") || !binScent.GetBool("isGameOver"))
			if(GameManager.finishInstructions)
				trash.velocity = new Vector2 (WaveManager.waveSpeed,trash.velocity.y);
		anim.SetBool ("changeSprite", false);
		if (RandomNow) {
			randomizer_Kind = Random.Range(0,4);
			randomizer_Sprite = Random.Range(0,8);
		}
		anim.SetInteger ("whichKind", randomizer_Kind);
		anim.SetInteger ("whichSprite", randomizer_Sprite);
		anim.SetBool ("changeSprite", true); 

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Bin") {
			fallingTrash.transform.position = trashSpawn.position;
			spawnCount +=1;
			//Debug.Log(spawnCount);
			RandomNow = true;
			if (binScent.GetInteger ("State")==anim.GetInteger ("whichKind")) {

				rightAnswers +=1;
				if(spawnCount % 10 ==0 && spawnCount!=0){
					WaveManager.updateWave = true;
					Debug.Log("sulod");
				}
				if(Lives.lives !=0)
					ScoreManager.score += 10;
			} else{
				Storage.storeInfo(storeThisAnimation.sprite,randomizer_Kind,binScent.GetInteger ("State"));
				if(Lives.lives != 0)
					Lives.lives -=1;
				//Debug.Log(randomizer_Kind);

			}
			if(ScoreManager.score == 500){
				SaveLoad.Load();
				MCData.current.SaveStage(0);
				GameManager.MissionAccompishTransition();
				WaveManager.waveSpeed = 0;
			}
			// testing
			if(Lives.lives == 0){
				Debug.Log ("dlaskjdlkasdjaslkdjaslkdjas deado");
				//trash.velocity = new Vector2 (0f,0f);
				GameManager.ExplodeAndTransition();
			}
		}
	}
	


	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == ("Bin")) {
			RandomNow = false;
		}
	}



}