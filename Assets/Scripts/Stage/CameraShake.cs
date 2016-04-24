using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;


public class CameraShake : MonoBehaviour {

	public static CameraShake instance {get; private set;}

	public float duration;
	public float magnitude;
	
	public bool test = false;


	public AudioClip earthquakemode;
	private AudioSource source;

	void Awake(){
		source = gameObject.GetComponent<AudioSource>();
		instance = this;
	}

	// -------------------------------------------------------------------------
	public void PlayShake(float _magnitude) {
		magnitude = _magnitude;
		StopAllCoroutines();
		StartCoroutine("Shake");
	}
	
	// -------------------------------------------------------------------------
	void Update() {
		if (test) {
			test = false;
		}
	}

	IEnumerator Shake() {
		if(QuakeService.instance._intensityValue >= 5)
			source.PlayOneShot(earthquakemode);
		if(magnitude > 4.0 && PlatformerCharacter2D.instance.m_Anim.GetFloat("Speed") > 0.6){
			EaroStatus.isCut = true;
		}

		float elapsed = 0.0f;

		while (elapsed < duration - 0.05) {

			elapsed += Time.deltaTime;          
			
			float percentComplete = elapsed / duration;         
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;
			x *= (magnitude/800) * damper;
			y *= (magnitude/800) * damper;




			Camera.main.transform.position = new Vector3(x+(Camera.main.transform.position.x), y+(Camera.main.transform.position.y), (Camera.main.transform.position.z));
			Handheld.Vibrate();
			yield return null;
		}

	}
}
