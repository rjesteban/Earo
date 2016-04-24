using UnityEngine;
using System.Collections;

public class DragTrash : MonoBehaviour {
	private Transform dragThis;
	private bool mouseHere;
	private Vector3 currentPos;
	private Vector3 screenPoint;
	private bool triggerCollider;
	private int whenGO;
	public Vector2 spawnValues;
	public LayerMask BinsLayers;
	//private Vector3 offset;
	// Use this for initialization
	void Start () {
		whenGO = 0;
		//Debug.Log ("wtf");
		dragThis = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (GameManagerMC2.GameOver) {
			gameObject.SetActive(false);
			GameObject.Find ("BioBin").GetComponent<SpriteRenderer>().enabled =false;
			GameObject.Find ("NonBioBin").GetComponent<SpriteRenderer>().enabled =false;
			GameObject.Find ("BulkyBin").GetComponent<SpriteRenderer>().enabled =false;
			GameObject.Find ("HazardBin").GetComponent<SpriteRenderer>().enabled =false;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){

		if (collider.name == "GameOverCollider") {
			//;
			whenGO++;
			StartCoroutine (checkGameOver(collider));
		}
		if (collider.name == "NonBioBin") {
			Debug.Log("why");
			GameObject.Find("NonBioBin").GetComponent<Animator>().SetBool("isHovered",true);
			
		}
		if (collider.name == "BioBin") {
			GameObject.Find("BioBin").GetComponent<Animator>().SetBool("isHovered",true);

		}

		else if (collider.name == "BulkyBin") {
			GameObject.Find("BulkyBin").GetComponent<Animator>().SetBool("isHovered",true);
			
		}
		else if (collider.name == "HazardBin") {
			GameObject.Find("HazardBin").GetComponent<Animator>().SetBool("isHovered",true);
			
		}

		//if (collider.name == "NonBioBin")
			////
	}

//	void OnCollisionEnter2D(Collision2D collider){
//		if (collider.collider(GameObject.Find("BioBin").GetComponent<Collider2D>())) {
//		} else if (collider.collider.name == "NonBioBin") {
//			GameObject.Find("NonBioBin").GetComponent<Animator>().SetBool("isHovered",true);
//		} else if (collider.collider.name == "BulkyBin") {
//			GameObject.Find("BulkyBin").GetComponent<Animator>().SetBool("isHovered",true);
//		} else if (collider.collider.name == "HazardBin") {
//			GameObject.Find("HazardBin").GetComponent<Animator>().SetBool("isHovered",true);
//		}
//	}

	IEnumerator checkGameOver(Collider2D collider){
		if (collider.name == "GameOverCollider") {
			yield return new WaitForSeconds (1.5f);

			if(collider.name == "GameOverCollider")
				if (whenGO == 1)
					GameManagerMC2.GameOver = true;
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if (collider.name == "GameOverCollider") {
			whenGO--;
		}
		
		if (collider.name == "BioBin") {
			GameObject.Find("BioBin").GetComponent<Animator>().SetBool("isHovered",false);
			//Debug.Log(GameObject.Find("BioBin").GetComponent<Animator>().GetBool("isHovered"));
		}
		if (collider.name == "NonBioBin") {
			GameObject.Find("NonBioBin").GetComponent<Animator>().SetBool("isHovered",false);
			
		}
		if (collider.name == "BulkyBin") {
			GameObject.Find("BulkyBin").GetComponent<Animator>().SetBool("isHovered",false);
			
		}
		if (collider.name == "HazardBin") {
			GameObject.Find("HazardBin").GetComponent<Animator>().SetBool("isHovered",false);
			
		}
	}

	void OnMouseClick(){
	}


	void OnMouseExit(){
		//mouseHere = false;
	}

	void OnMouseUp(){
		gameObject.GetComponent<CircleCollider2D>().isTrigger = false;

		if (gameObject.GetComponent<CircleCollider2D> ().IsTouching (GameObject.Find ("Background").GetComponent<PolygonCollider2D> ())) {
			gameObject.transform.position = new Vector2(Random.Range(-3.4f, 5.1f), spawnValues.y);
			whenGO = 0;
		}
		if(gameObject.GetComponent<CircleCollider2D>().IsTouching(GameObject.Find("BioBin").GetComponent<BoxCollider2D>())){
			//Debug.Log("BABE!");
			if(gameObject.tag == "Biodegradable"){
				GameManagerMC2.timesCorrect+=1;
				GameManagerMC2.Score  += Random.Range(1,3);
				Destroy(gameObject);
				GameObject.Find("BioBin").GetComponent<Animator>().SetBool("isHovered",false);
				if(GameManagerMC2.timesCorrect %10 == 0 && GameManagerMC2.Score != 0){
					//Debug.Log("KANII"+ GameManager.timesCorrect);
					//GameManager.spawnWait -=0.5f;
					GameManagerMC2.Waves+=1;
				}
			}
			else
				GameManagerMC2.binMistakes[0]++;
		}
		else if(gameObject.GetComponent<CircleCollider2D>().IsTouching(GameObject.Find("NonBioBin").GetComponent<BoxCollider2D>())){
			//Debug.Log("1231!");
			if(gameObject.tag == "NonBiodegradable"){
				GameManagerMC2.timesCorrect+=1;
				GameManagerMC2.Score  += Random.Range(1,3);
				Destroy(gameObject);
				GameObject.Find("NonBioBin").GetComponent<Animator>().SetBool("isHovered",false);
				if(GameManagerMC2.timesCorrect %10 == 0 && GameManagerMC2.Score != 0){
					//Debug.Log("KANII"+ GameManager.timesCorrect);
					//GameManager.spawnWait -=0.5f;
					GameManagerMC2.Waves+=1;
				}
			}
			else
				GameManagerMC2.binMistakes[1]++;
		}
		else if(gameObject.GetComponent<CircleCollider2D>().IsTouching(GameObject.Find("BulkyBin").GetComponent<BoxCollider2D>())){
			//Debug.Log("BAB51463E!");
			if(gameObject.tag == "Bulky"){
				GameManagerMC2.timesCorrect+=1;
				GameManagerMC2.Score  += Random.Range(1,3);
				Destroy(gameObject);
				GameObject.Find("BulkyBin").GetComponent<Animator>().SetBool("isHovered",false);
				if(GameManagerMC2.timesCorrect %10 == 0 && GameManagerMC2.Score != 0){
					//Debug.Log("KANII"+ GameManager.timesCorrect);
					//GameManager.spawnWait -=0.5f;
					GameManagerMC2.Waves+=1;
				}
			}
			else
				GameManagerMC2.binMistakes[2]++;
		}
		else if(gameObject.GetComponent<CircleCollider2D>().IsTouching(GameObject.Find("HazardBin").GetComponent<BoxCollider2D>())){
			//Debug.Log("5865!");
			if(gameObject.tag == "Hazardous"){
				GameManagerMC2.timesCorrect+=1;
				GameManagerMC2.Score  += Random.Range(1,3);
				Destroy(gameObject);
				GameObject.Find("HazardBin").GetComponent<Animator>().SetBool("isHovered",false);
				if(GameManagerMC2.timesCorrect %10 == 0 && GameManagerMC2.Score != 0){
					//Debug.Log("KANII"+ GameManager.timesCorrect);
					//GameManager.spawnWait -=0.5f;
					GameManagerMC2.Waves+=1;
				}
			}
			else
				GameManagerMC2.binMistakes[3]++;
		}
	}

	void OnMouseDrag(){
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		triggerCollider = true;
		dragThis.localPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z+10));
		gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
	}
	

}




