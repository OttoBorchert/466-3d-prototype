using UnityEngine;
using System.Collections;

public class PlayOneShotScript : MonoBehaviour {

	public AudioClip soundToPlay;

	private AudioSource audioSource;

	// Use this for initialization
	void Awake () {
		audioSource = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	public void PlayOneShot() {
		audioSource.PlayOneShot (soundToPlay);
	}
}
