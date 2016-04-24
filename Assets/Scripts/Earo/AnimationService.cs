using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets._2D;

public class AnimationService : MonoBehaviour {

	public static AnimationService instance{get; private set;}

	public Image damageImage;
	public Text text;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	private bool damaged;

	public GameObject Bruise;
	public GameObject Drowned;
	public GameObject MinorCutsAndWounds;
	public GameObject Sprain;

	public GameObject FirstDegBurn;
	public GameObject SecondDegBurn;
	public GameObject ThirdDegBurn;

	void Awake(){
		instance = this;
	}

	void Update(){
		if(damaged){
			damageImage.color = flashColour;
		}
		else{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}
	
	public IEnumerator isDead(){
		text.text = "Fatal Hit";
		damaged = true;
		EaroAudioService.instance.playHit();
		PlatformerCharacter2D.instance.m_Anim.SetBool("Hit", true);
		yield return new WaitForSeconds(1.0f);
		Debug.Log("levelname " + Application.loadedLevelName);
		if(Application.loadedLevelName == "Stage1")
			Application.LoadLevel("Failed");
		else
			Application.LoadLevel("Failed2");
	}
	
	public IEnumerator isCut(){
		damaged = true;
		EaroAudioService.instance.playHit();
		PlatformerCharacter2D.instance.m_Anim.SetBool("Hit", true);
		yield return new WaitForSeconds(1.0f);
		Instantiate (MinorCutsAndWounds);
	}

	public IEnumerator isBruised(){
		damaged = true;
		EaroAudioService.instance.playHit();
		PlatformerCharacter2D.instance.m_Anim.SetBool("Hit", true);
		yield return new WaitForSeconds(1.0f);
		Instantiate(Bruise);
	}

	public IEnumerator isSprained(){
		damaged = true;
		EaroAudioService.instance.playBoneBreak();
		PlatformerCharacter2D.instance.m_Anim.SetBool("Hit", true);
		yield return new WaitForSeconds(1.0f);
		Instantiate (Sprain);
	}

	public IEnumerator isDrowned(){
		damaged = true;
		PlatformerCharacter2D.instance.m_Anim.SetBool("Hit", true);
		yield return new WaitForSeconds(1.0f);
		Instantiate (Drowned);
	}

	//-------------Burns------------------

	public IEnumerator isFirstDegBurned(){
		damaged = true;
		EaroAudioService.instance.playHit();
		PlatformerCharacter2D.instance.m_Anim.SetBool("Hit", true);
		yield return new WaitForSeconds(1.0f);
		Instantiate(FirstDegBurn);
	}

	public IEnumerator isSecondDegBurned(){
		damaged = true;
		EaroAudioService.instance.playHit();
		PlatformerCharacter2D.instance.m_Anim.SetBool("Hit", true);
		yield return new WaitForSeconds(1.0f);
		Instantiate(SecondDegBurn);
	}

	public IEnumerator isThirdDegBurned(){
		damaged = true;
		EaroAudioService.instance.playHit();
		PlatformerCharacter2D.instance.m_Anim.SetBool("Hit", true);
		yield return new WaitForSeconds(1.0f);
		Instantiate(ThirdDegBurn);
	}

	//-------------Status------------------

	public IEnumerator EaroWasSaved(){
		text.text = "Earo was Saved!";
		yield return new WaitForSeconds(2.0f);
		text.text = "";
	}

	public IEnumerator EaroWasNotSaved(){
		text.text = "Earo was not saved!";
		yield return new WaitForSeconds(2.0f);
		text.text = "";
		Debug.Log("levelname " + Application.loadedLevelName);
		if(Application.loadedLevelName == "Stage1")
			Application.LoadLevel("Failed");
		else
			Application.LoadLevel("Failed2");
	}

	public IEnumerator TimesUp(){
		text.text = "Times Up!";
		PlatformerCharacter2D.instance.m_Anim.SetBool("Hit", true);
		yield return new WaitForSeconds(2.0f);
		text.text = "";
		Debug.Log("levelname " + Application.loadedLevelName);
		if(Application.loadedLevelName == "Stage1")
			Application.LoadLevel("Failed");
		else
			Application.LoadLevel("Failed2");
	}
}
