using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pumpClicked : MonoBehaviour {
	public GameObject hand;
	public GameObject correctBar;
	private Collider2D thisIsCorrect;
	private Collider2D thisIsHand;
	// Use this for initialization
	void Start () {
		thisIsHand = hand.GetComponent<BoxCollider2D> ();
		thisIsCorrect = correctBar.GetComponent < BoxCollider2D> (); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void isClicked(){
		if (thisIsHand.bounds.Intersects (thisIsCorrect.bounds)) {
			if(CPRManager.pumps!=30)
				CPRManager.pumps += 1;
			GameObject.Find ("PumpsText").GetComponent<Text> ().text = "Pumps: " + CPRManager.pumps;
			Debug.Log (CPRManager.pumps);
		} else {
			if(CPRManager.lives!=0)
				CPRManager.lives -= 1;
			GameObject.Find ("LivesText").GetComponent<Text> ().text = "Lives: " + CPRManager.lives;
		}
	}
}
