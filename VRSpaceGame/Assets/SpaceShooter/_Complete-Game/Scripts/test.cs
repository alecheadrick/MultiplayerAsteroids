using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test: MonoBehaviour {
	void Start(){
		StartCoroutine(checkTurrets());
	}
	IEnumerator checkTurrets() {
		bool rightFound = false;
		bool leftFound = false;
		bool completed = false;
		while (!completed) {
			if (GameObject.Find("boss ship/Turrets/right") == null && !rightFound) {rightFound = true; Debug.Log ("right turret destroyed");}
			if (GameObject.Find("boss ship/Turrets/left") == null && !leftFound) {leftFound = true; Debug.Log ("left turret destroyed");}
			if (rightFound && leftFound) {
				Debug.Log ("no turrets found");
				SphereCollider sc = gameObject.AddComponent(typeof (SphereCollider)) as SphereCollider;
				Debug.Log ("added sphere collider");
				completed = true;
			}
				yield return null;
		}
	}
}