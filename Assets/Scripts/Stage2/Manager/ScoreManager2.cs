using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager2 : MonoBehaviour {
	public Text text;
	public int finalScore ;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}	
	// Update is called once per frame
	void Update () {
		if(LifeSaver.rightAnswer>=0)
			finalScore =  LifeSaver.rightAnswer;

		text.text = "People Saved: " + finalScore;
		}
}
