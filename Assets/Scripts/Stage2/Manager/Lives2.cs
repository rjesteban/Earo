using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lives2 : MonoBehaviour {
	public Text text;
	public int livesLeft ;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}	
	// Update is called once per frame
	void Update () {
		if(LifeSaver.m_lives>=0)
			livesLeft =  LifeSaver.m_lives;
		
		text.text = "Lives: " + livesLeft;
	}
}
