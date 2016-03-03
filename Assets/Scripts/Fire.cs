using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	public GameObject firePoint;
	public Collector collector;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name.StartsWith ("Ball")) {
			if (collector != null && firePoint != null) {
				GameObject objectToFire = collector.getNext ();
				if (objectToFire != null) {
					Rigidbody ball = objectToFire.GetComponent<Rigidbody>();
					ball.transform.position = firePoint.transform.position;
					Transform canon = firePoint.transform.parent;
					ball.velocity = canon.TransformDirection (-Vector3.forward * 20);
					Destroy (other.gameObject);
					PlayOneShotScript playOneShotScript = firePoint.GetComponent<PlayOneShotScript> ();
					playOneShotScript.PlayOneShot ();
				}
			} else {
				Debug.Log ("Error: Set firePoint and collector");
			}
		}
	}



}
