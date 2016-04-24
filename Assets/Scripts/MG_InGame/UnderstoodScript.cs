using UnityEngine;
using System.Collections;

public class UnderstoodScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Clicked(){
		GameObject.Find ("InstructionsCanvas").GetComponent<Canvas> ().enabled = false;
		GameManager.finishInstructions = true;

	}
}
