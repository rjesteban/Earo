using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets._2D;


public class EaroStatus : MonoBehaviour {

	public static EaroStatus instance{ get; private set;}

	public GameObject _object;
	public Animator animator;

	public static bool isAlive;
	public static bool ethereal;
	public static bool isBruised, isCut, isSprained, isDrowned;
	public static bool isFirstDegBurned, isSecondDegBurned, isThirdDegBurned;

	public GameObject etherealButton;


	void Awake(){

		etherealButton = GameObject.Find ("Ethereal");
		instance = this;
		isAlive = true;
		SaveLoad.Load ();
	}

	// Use this for initialization
	void Start () {
		etherealButton = GameObject.Find ("Ethereal");
		SaveLoad.Load ();
		if(SaveLoad.gender.Equals("G")){
			animator = PlatformerCharacter2D.instance.m_Anim;
			animator.runtimeAnimatorController = _object.gameObject.GetComponent<Animator>().runtimeAnimatorController;
			PlatformerCharacter2D.instance.m_Anim.runtimeAnimatorController = animator.runtimeAnimatorController;
			
		}
		else{
			
		}

		isFirstDegBurned = isBruised = isCut = ethereal = false;
	}
	
	// Update is called once per frame
	void Update () {
		// if ethereal print nga ethereal status

		//----------------life-------------------
		if(!isAlive){
			AnimationService.instance.StartCoroutine("isDead");
		}

		//--------------first aid?----------------
		if(isBruised){
			AnimationService.instance.StartCoroutine("isBruised");
			launchetherealMode();
			isBruised = !isBruised;
		}

		else if(isCut){
			AnimationService.instance.StartCoroutine("isCut");
			launchetherealMode();
			isCut = !isCut;
		}

		else if(isFirstDegBurned){
			AnimationService.instance.StartCoroutine("isFirstDegBurned");
			launchetherealMode();
			isFirstDegBurned = !isFirstDegBurned;
		}

		else if(isSecondDegBurned){
			AnimationService.instance.StartCoroutine("isSecondDegBurned");
			launchetherealMode();
			isSecondDegBurned = !isSecondDegBurned;
		}

		else if(isThirdDegBurned){
			AnimationService.instance.StartCoroutine("isThirdDegBurned");
			launchetherealMode();
			isThirdDegBurned = !isThirdDegBurned;
		}

		else if(isSprained){
			AnimationService.instance.StartCoroutine("isSprained");
			launchetherealMode();
			isSprained = !isSprained;
		}

		else if(isDrowned){
			AnimationService.instance.StartCoroutine("isDrowned");
			launchetherealMode();
			isDrowned = !isDrowned;
		}
	}

	void OnTriggerStay2D(Collider2D collider){
		if (collider.transform.tag == "Electric" && TriggerFallPost.canElectricute) {
			isAlive = false;
			Application.LoadLevel ("Failed");
		}
	}

	//----------------launch add time ------------------
	public void addTime(GameObject game){
		EaroAudioService.instance.playAddTime();
		game.gameObject.GetComponent<Button> ().interactable = false;
		StartCoroutine (coolDownAddTime (game));
	}

	IEnumerator coolDownAddTime(GameObject game){
		CountDownTimer.instance.time += 10.0f;
		yield return new WaitForSeconds (25.0f);
		game.gameObject.GetComponent<Button> ().interactable = true;
	}

	//---------------ethereal mode --------------------------

	public void launchetherealMode(){
		EaroAudioService.instance.playEtherealMode();
		if(!PlatformerCharacter2D.instance.m_Anim.GetBool("Hit"))
			etherealButton.gameObject.GetComponent<Button> ().interactable = false;
		ethereal = true;
		StopCoroutine (coolDownEtherealMode (etherealButton));
		StartCoroutine (coolDownEtherealMode (etherealButton));
	}

	IEnumerator coolDownEtherealMode(GameObject game){
		PlatformerCharacter2D.instance.launchEtherealMode();
		HeadCollision.instance.gameObject.GetComponent<Collider2D>().isTrigger = true;
		ArmCollision.instance.gameObject.GetComponent<Collider2D>().isTrigger = true;
		FeetCollision.instance.gameObject.GetComponent<Collider2D>().isTrigger = true;
		FeetCollision.instance.GetComponent<Rigidbody2D>().isKinematic = true;

		HeadCollision.instance.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
		FeetCollision.instance.GetComponent<Rigidbody2D>().gravityScale = 0;

		yield return new WaitForSeconds (5.0f);
		HeadCollision.instance.gameObject.GetComponent<Collider2D>().isTrigger = false;
		HeadCollision.instance.GetComponent<Rigidbody2D>().isKinematic = false;
		ArmCollision.instance.gameObject.GetComponent<Collider2D>().isTrigger = false;
		FeetCollision.instance.gameObject.GetComponent<Collider2D>().isTrigger = false;
		FeetCollision.instance.GetComponent<Rigidbody2D>().isKinematic = false;

		HeadCollision.instance.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
		FeetCollision.instance.GetComponent<Rigidbody2D>().gravityScale = 1;
		yield return new WaitForSeconds (20.0f);
		game.gameObject.GetComponent<Button> ().interactable = true;
	}

}
