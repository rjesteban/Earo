using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTransfer : MonoBehaviour {
	private Text text;
	public static int finScore;

	// Use this for initialization
	void Start () {
		finScore = Storage.finScore;
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score: " + finScore;
	}
}
