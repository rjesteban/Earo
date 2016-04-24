using UnityEngine;
using System.Collections;

public class RetryButton: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Clicked(){
		Application.LoadLevel("MiniGame1_InGame");
	}
}
