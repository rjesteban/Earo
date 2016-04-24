using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class tiltClicked : MonoBehaviour {
	public Slider tiltSlider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void isClicked(){
		if(tiltSlider.value ==3){
			CPRManager.CurrentStep = 3;
			Debug.Log (CPRManager.CurrentStep);
			CPRManager.instance.startGame ();
		}

	}

}
