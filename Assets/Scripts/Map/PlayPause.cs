using UnityEngine;
using System.Collections;

public class PlayPause : MonoBehaviour {
	
	public static PlayPause instance{get; private set;}

	void Awake(){
		instance = this;
	}

	public void DestroyPanel(){
		Destroy(gameObject);
	}
}
