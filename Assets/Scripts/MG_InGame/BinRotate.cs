using UnityEngine;
using System.Collections;

public class BinRotate : MonoBehaviour {
	private Animator _anim;
	private int rState;
	public bool canRotateAgain;
	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator> ();
		_anim.SetInteger ("State", rState);
		rState = 0;
	}

	
	// Update is called once per frame
	void Update () {
//			if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("BinRotate1") || this.anim.GetCurrentAnimatorStateInfo (0).IsName ("BinIdle1")
//		    	|| this.anim.GetCurrentAnimatorStateInfo (0).IsName ("BinRotate2") || this.anim.GetCurrentAnimatorStateInfo (0).IsName ("BinIdle2")
//		    	|| this.anim.GetCurrentAnimatorStateInfo (0).IsName ("BinRotate3") || this.anim.GetCurrentAnimatorStateInfo (0).IsName ("BinIdle3")
//		    	|| this.anim.GetCurrentAnimatorStateInfo (0).IsName ("BinRotate4") || this.anim.GetCurrentAnimatorStateInfo (0).IsName ("BinIdle4")) {
//				canRotateAgain = true;
//			} else if(canRotateAgain)
//				canRotateAgain = false;

//
//			if (Input.GetKeyDown ("left") && rState == 0 ) {
////				if(canRotateAgain)
//					rState = 1;
//				anim.SetTrigger ("triggerState");
//				anim.SetInteger ("State", rState);
//
//			} else 	if (Input.GetKeyDown ("left") && rState == 1 ) {
////				if(canRotateAgain)
//					rState = 2;
//				anim.SetTrigger ("triggerState");
//				anim.SetInteger ("State", rState);
//
//			} else if (Input.GetKeyDown ("left") && rState == 2 ) {
////				if(canRotateAgain)
//					rState = 3;
//				anim.SetTrigger ("triggerState");;
//				anim.SetInteger ("State", rState);
//
//			} else if (Input.GetKeyDown ("left") && rState == 3 ) {
////				if(canRotateAgain)	
//					rState = 0;	
//				anim.SetTrigger ("triggerState");
//				anim.SetInteger ("State", rState);

			} //else {
				//anim.SetTrigger ("triggerState");
			//}


	public void RotateTheBin(GameObject _rotate){
		Animator anim = _rotate.gameObject.GetComponent<Animator> ();

		if (rState == 0 ) {
			//				if(canRotateAgain)
			rState = 1;
			anim.SetTrigger ("triggerState");
			anim.SetInteger ("State", rState);
			
		} else 	if (rState == 1 ) {
			//				if(canRotateAgain)
			rState = 2;
			anim.SetTrigger ("triggerState");
			anim.SetInteger ("State", rState);
			
		} else if (rState == 2 ) {
			//				if(canRotateAgain)
			rState = 3;
			anim.SetTrigger ("triggerState");;
			anim.SetInteger ("State", rState);
			
		} else if (rState == 3 ) {
			//				if(canRotateAgain)	
			rState = 0;	
			anim.SetTrigger ("triggerState");
			anim.SetInteger ("State", rState);
			
		}
	}

}
