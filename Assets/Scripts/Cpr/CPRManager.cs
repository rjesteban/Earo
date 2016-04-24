using UnityEngine;
using System.Collections;

public class CPRManager : MonoBehaviour {
	public static int CurrentStep;
	//private static bool nextStep;
	public static int pumps;
	public static int lives;
	public GameObject steps;
	public RectTransform handTransform;
	public RectTransform stepBar;
	public RectTransform hitBar;
	private float castY;
	private float maxX;
	private float minX;
	private Animator stepsAnimator;

	public Canvas Failed;
	public Canvas Accomplished;


	public static CPRManager instance{ get; private set; }

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		//GameManager2.instance.StopAllCoroutines();
		lives = 3;
		pumps = 0;
		//nextStep = false;
		handTransform.localPosition = new Vector2(handTransform.localPosition.x, GameObject.Find("Bar").GetComponent<RectTransform>().rect.min.y+10f);
		//castY = handTransform.position.y;
		minX = GameObject.Find("Bar").GetComponent<RectTransform>().rect.min.x;
		maxX = GameObject.Find("Bar").GetComponent<RectTransform>().rect.max.x;
		stepsAnimator = steps.GetComponent<Animator>();
		Debug.Log (maxX);
		//startGame ();
	}
	
	// Update is called once per frame
	void Update (){
	}

	public void startGame(){
		Debug.Log (CurrentStep);
		if (CurrentStep == 1){
			StartCoroutine ("FirstStep");
			stepsAnimator.SetInteger("transitionNow",1);

		}
		if(CurrentStep == 2){
			stepsAnimator.SetInteger("transitionNow",2);
			GameObject.Find("Step1").GetComponent<Canvas>().enabled = false;
			GameObject.Find ("Step2").GetComponent<Canvas>().enabled = true;
		}
		if(CurrentStep == 3){
			stepsAnimator.SetInteger("transitionNow",3);
			GameObject.Find ("Step2").GetComponent<Canvas> ().enabled = false;
			GameObject.Find("Step3").GetComponent<Canvas> ().enabled = true;  
		}
		if(CurrentStep == 4){
			stepsAnimator.SetInteger("transitionNow",4);
			GameObject.Find ("Step3").GetComponent<Canvas> ().enabled = false;
			GameObject.Find("Step4").GetComponent<Canvas> ().enabled = true; 
		}
		
		Debug.Log (CurrentStep);
	}

	IEnumerator FirstStep(){
		Debug.Log (maxX);
		while (pumps<10&&lives>0) {
			if (checkPosMax ()) {
				for (; handTransform.localPosition.x<=maxX;) {
					//Debug.Log (handTransform.localPosition);	
					handTransform.position = new Vector2 (handTransform.position.x + 5f, handTransform.position.y);
					yield return new WaitForSeconds (.000000000000001f);
				}
				for(;handTransform.localPosition.x>=minX;){
					//Debug.Log (handTransform.localPosition);	
					handTransform.position = new Vector2 (handTransform.position.x - 5f,handTransform.position.y);
					yield return new WaitForSeconds(.0000000000000001f);
				}
			}
		}
		if(pumps >= 10){
			CurrentStep =2;
			startGame();
		}
		if(lives == 0){
			LifeSaver.rightAnswer--;
			Failed.enabled = true;
		}
	}
	
	private bool checkPosMax(){
		if (handTransform.position.x == maxX)
			return false;
		else 
			return true;
	}
	private bool checkPosMin(){
		if (handTransform.position.x == minX)
			return false;
		else 
			return true;
	}

	public void openAccomplishedCanvas(){
		Accomplished.enabled = true;
	}
}
