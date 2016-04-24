using UnityEngine;
using System.Collections;

public class StoredInfo : MonoBehaviour {
	public Transform storeThis;
	//ToKeepThingsEvenWithSceneChange
	void Awake(){
		//if (!Application.loadedLevelName.Equals(MiniGame_InGame))
			DontDestroyOnLoad (storeThis);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
