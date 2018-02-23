using UnityEngine;
using System.Collections;

public class playerPos : MonoBehaviour {

	public Vector3 playerPosi;
	private bool u = true;
	// Use this for initialization
	void start () {
		while (u == true) {
			playerPosi = GameObject.Find("Done_Player").transform.position;
		}
	}
}