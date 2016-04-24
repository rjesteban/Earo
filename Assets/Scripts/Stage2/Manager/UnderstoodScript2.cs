using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnderstoodScript2 : MonoBehaviour {
	// Use this for initialization
	public static Canvas instruction ;
	void Start () {
		//Clicked();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Clicked(){
		Debug.Log("sdfsdf");
		instruction =GameObject.Find ("InstructionCanvas").GetComponent<Canvas>();
		instruction.enabled = false;
		GameManager2.finishInstructions = true;
	}
}
