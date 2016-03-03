using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicPlayerScript : MonoBehaviour {
	//A list of the songs our music player knows about
	public List<AudioClip> songs;

	//A reference to the AudioSource so we can set and play Audio Clips
	private AudioSource audioSource;

	//Constants to make switching between songs in the player a little more readable
	public const int BASIC_MUSIC = 0;
	public const int BOSS_MUSIC = 1;

	//Set the song that's currently playing to the regular song
	private int playing = BASIC_MUSIC;

	//Plays the specified song (by index)
	//PRE: songToPlay is between 0 and songs.Count
	//@param songToPlay The index into songs that you want to play, Should use one of the constants of MusicPlayerScript
	public void PlaySong(int songToPlay) {
		audioSource.Stop ();
		audioSource.clip = songs [songToPlay];
		audioSource.Play ();
		playing = songToPlay;
	}

	// Use this for initialization
	void Start () {
		//Loads our AudioSource so we can use it in PlaySong
		audioSource = GetComponent<AudioSource> ();

	
	}
	
	// Update is called once per frame
	void Update () {
		//If no song is playing, loop it for us
		if (!audioSource.isPlaying) {
			PlaySong (playing);
		}
	}




}
