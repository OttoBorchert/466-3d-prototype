using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Throw : MonoBehaviour {

	public Rigidbody objectToThrow;
	public List<Color> colorList;

	// Use this for initialization
	void Start () {
		List<int> newList = new List<int> ();
		newList.Add (5);
		newList.Add (6);
		newList.Add (7);
		newList.Remove (6);
		for (int i = 0; i < newList.Count; i++) {
			Debug.Log (newList [i]);
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if (objectToThrow != null) {
			if (Input.GetButtonUp ("Fire1")) {
				Rigidbody ball = Instantiate (objectToThrow, transform.position, transform.rotation) as Rigidbody;

				MeshRenderer renderer = ball.GetComponent<MeshRenderer> ();
				Color newColor = new Color (Random.value, Random.value, Random.value);
				if (colorList.Count > 0) {
					newColor = colorList [(int)(Random.value * colorList.Count)];
				}

				renderer.material.color = newColor;
				ball.velocity = transform.TransformDirection (Vector3.forward * 10);
			}
		}
	}
}
