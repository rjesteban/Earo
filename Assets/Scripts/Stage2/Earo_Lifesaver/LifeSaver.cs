using UnityEngine;
using System.Collections;
public class LifeSaver : MonoBehaviour {
	
	public GameObject parent;
	public static int rightAnswer;
	public static int m_lives;
	public static int count;
	//public Animator  anim;

	// Use this for initialization
	void Start () {
		rightAnswer = 0;
		m_lives = 3;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
			bool pdeNa = parent.gameObject.GetComponent<laneCheck>().pwedeNaMahug;
		if(other.gameObject.transform.tag != "Player" && parent.gameObject.GetComponent<laneCheck>().anim.GetBool("Hulog") == true ){
			if(other.gameObject.transform.tag == "theSurvivors"  && parent.gameObject.GetComponent<laneCheck>().anim.GetBool("Hulog") == true){
				rightAnswer += 1;
				Debug.Log("IGO and right answer"+ rightAnswer);
				Destroy(other.gameObject);
//				if(rightAnswer%5==0){
//					GameManager2.instance.instantiateCPR();
//					GameManager.instance.StopAllCoroutines();
//				}
				if( rightAnswer == 15)
					GameManager2.instance.isAccomplished();
				}
			else 
			if(other.gameObject.transform.tag == "trash"  && parent.gameObject.GetComponent<laneCheck>().anim.GetBool("Hulog") == true){
				m_lives -= 1;
				StartCoroutine(destroyobject(other));
				Debug.Log("IGO and WRONG answer"+ m_lives);
				if( m_lives == 0)
					GameManager2.instance.isMissionFailed();
			}
			pdeNa = false;
			parent.gameObject.GetComponent<laneCheck>().anim.SetBool("Hulog", pdeNa);
		}
	}

	IEnumerator destroyobject(Collider2D other){
		other.gameObject.GetComponent<Animator>().SetBool("isWrong", true);
		yield return new WaitForSeconds(0.6f);
		Destroy(other.gameObject);
	}
}