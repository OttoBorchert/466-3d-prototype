using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuardMovementScript : MonoBehaviour {

	//The path the guard walks along
	public List<Transform> path;

	//The vector the guard is currently walking along
	private Vector3 walkVector;

	//The current and next spots on the path the guard will visit
	private int currentPathIndex;
	private int nextPathIndex;

	//Reference to animator to change parameters
	private Animator myAnimator;

	//Whether we're walking or not
	private bool walking = true;

	//Whether we've danced or not (only do it once)
	private bool danced = false;


	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator> ();
		myAnimator.SetBool ("walking", walking );

		if (path != null && path.Count > 1) {
			currentPathIndex = 0;
			nextPathIndex = 1;
			walkVector = path [nextPathIndex].position - path [currentPathIndex].position;
		}
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 newWalkVector = path [nextPathIndex].position - gameObject.transform.position;

		if (Vector3.Dot(walkVector, newWalkVector) < 0) { //We've gone past the next waypoint
			if (walking) {
				walking = false;
				myAnimator.SetBool ("walking", walking );
				Invoke ("WalkToNext", 5.0f);
			}
		}
	}

	//Creates a ring out of our path list
	//Once you reach the end of the list, the next index is the first
	int getNextIndex() {
		int nextIndex = nextPathIndex + 1;
		if (nextIndex >= path.Count) {
			nextIndex = 0;
		}
		return nextIndex;
	}

	//Turn the character so it's pointing in our new direction
	void RotateToNext() {
		Vector3 currentPosition = path[nextPathIndex].position;
		Vector3 nextPosition = path [getNextIndex ()].position;
		Vector3 newLookDirection = (nextPosition - currentPosition).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(newLookDirection);
		gameObject.transform.rotation = lookRotation;
	}

	//Walk to the next point on the path (the walking animation also translates, so we don't need to move the guard)
	void WalkToNext() {
		RotateToNext ();
		walking = true;
		myAnimator.SetBool ("walking", walking );
		currentPathIndex = nextPathIndex;
		nextPathIndex = getNextIndex ();
		walkVector = path [nextPathIndex].position - path [currentPathIndex].position;
	}

	//For dancing!
	void OnTriggerEnter(Collider other) {
		//Note, if we don't use this boolean flag, the guard will never stop dancing (because it constantly hits the trigger)
		if (!danced) {
			danced = true;
			myAnimator.SetBool ("walking", false);
			myAnimator.SetInteger ("activity", 1);
			Invoke ("StopDance", 1.0f);
		}
	}

	//Making sure the guard goes back to walking
	void StopDance() {
		myAnimator.SetInteger ("activity", 0);
		myAnimator.SetBool ("walking", true);
	}
}
