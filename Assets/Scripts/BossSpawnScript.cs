using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossSpawnScript : MonoBehaviour {

	//A reference to our music player, so we can change songs when the boss fight starts
	private MusicPlayerScript musicPlayer;

	//The amount of time left before the boss fight in seconds
	public float timeLeft = 15f;

	//A reference to the UI component, so that we can update the user interface
	public Text timeLeftUI; 

	//The thing that we'll instantiate when the timer runs out
	public GameObject boss;

	//Just a flag to determine if the boss has started or not
	private bool bossStarted = false;


	// Use this for initialization
	void Start () {
		//Gets our MusicPlayerScript (remember, get the object first, then the component on that object
		GameObject musicPlayerObject = GameObject.Find ("MusicPlayer");
		musicPlayer = musicPlayerObject.GetComponent<MusicPlayerScript> ();
	}
	
	// Update is called once per frame
	void Update () {


		if (timeLeft > 0) { //What happens before the boss fight
			timeLeft -= Time.deltaTime; //Time.deltaTime is the number of seconds that have occured since the last frame
			timeLeftUI.text = "Time Left: " + (int)timeLeft; //If we don't do the integer cast, it'll display the full floating point number
		}
		else  {
			if (!bossStarted) { //Play the new song when the boss starts and turn off the UI
				bossStarted = true;
				musicPlayer.PlaySong (MusicPlayerScript.BOSS_MUSIC);
				timeLeftUI.enabled = false;
			}
			// This is mostly for fun. What do you think will happen? 
			Instantiate (boss, this.gameObject.transform.position, Quaternion.identity);
		}
	}
}
