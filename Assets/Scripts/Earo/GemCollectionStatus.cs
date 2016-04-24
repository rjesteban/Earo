using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GemCollectionStatus : MonoBehaviour {

	public static GemCollectionStatus instance{get; private set;}

	public List<GameObject> gemites;
	public GameObject door;
	public int collected;
	public int toCollect;
	private Text _text;

	void Awake(){
		instance = this;
	}

	void Start () {
		gemites = new List<GameObject> (GameObject.FindGameObjectsWithTag("Gemite"));
		toCollect = gemites.Count;
		collected = 0;
		_text = GameObject.Find("GemitesRemaining").gameObject.GetComponent<Text> ();
	}

	void Update () {
		int _requirements = toCollect - gemites.Count;
		if (_requirements == 1) {
			Destroy (door);
		}

		string status = gemites.Count + "";
		_text.text = status;
	}
}
