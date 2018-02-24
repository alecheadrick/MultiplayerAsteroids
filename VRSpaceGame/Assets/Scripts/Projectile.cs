using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float lifetime = 5;
	public float shotForce = 100;

	// Use this for initialization
	void Start () {
		Object.Destroy (gameObject, lifetime);
		GetComponent<Rigidbody> ().AddForce (
			transform.forward * shotForce * 1, 
			ForceMode.Impulse);
	}

	// Update is called once per frame
	void Update () {
		//		Debug.Log ("Position x/y/z: " + transform.position.x + "/" + transform.position.y
		//		+ "/" + transform.position.z);
		//		Debug.Log ("Rotation x/y/z: " + transform.rotation.eulerAngles.x + "/" + 
		//			transform.rotation.eulerAngles.y + "/" + transform.rotation.eulerAngles.z);
	}
}
