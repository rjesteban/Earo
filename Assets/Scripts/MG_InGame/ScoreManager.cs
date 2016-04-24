using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	private Text text;
	public static int score;

	// Use this for initialization
	void Start () {
		score = 0;
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		text.text = "Score: " + score;
	}
}