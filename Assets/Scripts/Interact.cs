using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name.StartsWith("Ball")) {
			Color color = new Color (Random.value, Random.value, Random.value);
			MeshRenderer gameObjectRenderer = this.GetComponent<MeshRenderer>();
			gameObjectRenderer.material.color = color;

			Destroy (other.gameObject);

			//Remove this comment to destroy the object when it's hit
			//Destroy (this.gameObject);
		}
	}
}
