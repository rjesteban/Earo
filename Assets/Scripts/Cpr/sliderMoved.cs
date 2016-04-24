using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sliderMoved : MonoBehaviour {
	public Slider tiltSlider;
	public Image tiltImage;
	private Animator tiltAnimator;
	// Use this for initialization
	void Start () {
		tiltAnimator = tiltImage.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeImage(){
		if(tiltSlider.value == 0 || tiltSlider.value == 1){
			tiltAnimator.SetInteger("sliderInt",1);
		}else if(tiltSlider.value == 2){
			tiltAnimator.SetInteger("sliderInt",2);
		}else if(tiltSlider.value == 3){
			tiltAnimator.SetInteger("sliderInt",3);
		}
	}
}
