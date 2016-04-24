using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance{get; private set;}

	void Awake(){
		instance = this;
	}

	public static bool transitionNow;
	public static bool finishInstructions;
	public static bool Store;

	public bool isPaused;

	// Use this for initialization
	void Start () {
		isPaused = false;
		finishInstructions = false;
		transitionNow = false;
		Store = true;
		GameObject.Find ("InstructionsCanvas").GetComponent<Canvas> ().enabled = true; 
	}
	// Update is called once per frame
	void Update () {
		StartCoroutine (waitAwhile ());
	}

	public static void ExplodeAndTransition(){
		Store = false;
		GameObject.Find ("Bins").GetComponent<Animator> ().SetBool ("isGameOver", true);
		if (GameObject.Find ("Bins").GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("BinDestroy")) {
			transitionNow = false;
		} else {
			transitionNow = true;
		}
	}

	public static void MissionAccompishTransition(){
		GameObject.Find ("Bins").GetComponent<Animator> ().SetBool ("isAccomplished", true);
		GameObject.Find ("AccomplishedCanvas").GetComponent<Canvas> ().enabled = true;
		transitionNow = false;
		finishInstructions = false;
	}

	IEnumerator  waitAwhile(){
		if (GameManager.transitionNow) {
			//Debug.Log ("OH YEEEAAAH SHIFT");
			yield return new WaitForSeconds (3.0f);
			Application.LoadLevel ("MiniGame1_GameOver");
			finishInstructions = false;
		}
	}

	public void play_pause(Text _text){
		if (!isPaused) {
			Time.timeScale = 0;
			_text.text = "Paused";
		} else {
			Time.timeScale = 1;
			_text.text = "";
		}
		isPaused = !isPaused;
	}
}