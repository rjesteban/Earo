using UnityEngine;
using System.Collections;

public class Cracken : MonoBehaviour {

	public Sprite cracken;
	public int intensity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(QuakeService.instance._intensityValue>=intensity)
			gameObject.GetComponent<SpriteRenderer>().sprite = cracken;
	}
}
