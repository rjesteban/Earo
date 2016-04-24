using UnityEngine;
using System.Collections;

public class okButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Clicked(){
		GameObject.Find ("Canvas").GetComponent<Canvas> ().enabled = true;
		GameObject.Find ("ClickedCanvas").GetComponent<Canvas> ().enabled = false;
	}
}
