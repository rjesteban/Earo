using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class EaroLifeSaverStatus : MonoBehaviour {

	public EaroLifeSaverStatus instance{get; private set;}
	public static int countLimit;
	public GameObject _lifeSaver;

	public GameObject _object;
	public Animator animator;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		countLimit = 0;
		SaveLoad.Load ();
		if(SaveLoad.gender.Equals("G")){
			animator = gameObject.GetComponent<Animator>();
			animator.runtimeAnimatorController = _object.gameObject.GetComponent<Animator>().runtimeAnimatorController;
			
		}
		else{
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.transform.tag == "Lane"){
			other.gameObject.GetComponent<laneCheck>().pwedeNaMahug = true;
			_lifeSaver = other.gameObject;
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.transform.tag == "Lane"){
			other.gameObject.GetComponent<laneCheck>().pwedeNaMahug = false;
			_lifeSaver = null;
		}
	}

	public void IhugNa(){
		if(_lifeSaver != null){
			_lifeSaver.GetComponent<laneCheck>().anim.SetBool("Hulog",_lifeSaver.GetComponent<laneCheck>().pwedeNaMahug);
		}
	}
	

}
