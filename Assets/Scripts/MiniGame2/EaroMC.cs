using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class EaroMC : MonoBehaviour {

	public GameObject _object;
	public Animator animator;

	// Use this for initialization
	void Start () {
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
}
