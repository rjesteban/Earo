using UnityEngine;
using System.Collections;

public class EaroAudioService : MonoBehaviour {

	public static EaroAudioService instance{get; private set;}

	public AudioClip etherealMode;
	public AudioClip addTime;
	public AudioClip boyEaroScream;
	public AudioClip boneBreak;

	private AudioSource source;
	
	// Use this for initialization
	void Awake () {
		source = gameObject.GetComponent<AudioSource>();
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playHit(){
		source.PlayOneShot(boyEaroScream);
	}

	public void playEtherealMode(){
		source.PlayOneShot(etherealMode);
	}

	public void playAddTime(){
		source.PlayOneShot(addTime);
	}

	public void playBoneBreak(){
		source.PlayOneShot(boneBreak);
	}
}
