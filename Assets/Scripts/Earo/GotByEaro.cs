using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GotByEaro : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col){
		Debug.Log("tag:====> " + col.transform.tag);
		if (col.transform.tag == "Player") {
			GemCollectionStatus.instance.collected++;
			GemCollectionStatus.instance.gemites.Remove(gameObject);
			Destroy (gameObject);
		}
	}
}
