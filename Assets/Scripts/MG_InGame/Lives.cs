using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lives : MonoBehaviour {
	public static int lives;
	public Text text;
	// Use this for initialization
	void Start () {
		lives = 3;
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Lives: " + lives;
	}
}
