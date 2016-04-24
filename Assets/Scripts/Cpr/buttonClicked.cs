using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttonClicked : MonoBehaviour {
	//public GameObject Instructions;
	//public GameObject Step1;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void isClicked(){
		CPRManager.CurrentStep = 1;
		GameObject.Find ("Instructions").SetActive (false);
		GameObject.Find("Step1").GetComponent<Canvas> ().enabled = true;  
		//Debug.Log (CPRManager.CurrentStep);
		CPRManager.instance.startGame ();
	}
}
