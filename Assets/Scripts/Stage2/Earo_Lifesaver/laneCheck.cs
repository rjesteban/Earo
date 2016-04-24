using UnityEngine;
using System.Collections;

public class laneCheck : MonoBehaviour {

	public bool pwedeNaMahug;
	public Animator anim;

	// Use this for initialization
	void Start () {
		pwedeNaMahug = false;
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}