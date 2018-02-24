using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public AudioClip fireNoise;
	public GameObject shotPrefab;
	public GameObject firstPersonCam;
	//public GameObject thirdPersonCam;
	public Transform[] shotSpawns;
	public float shotDelay = .5f;

	//private float throttle;
	private float lastShotTime;
	public int nextShotPoint = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GvrControllerInput.ClickButton && Time.time > lastShotTime + shotDelay)
		{
			Fire();
		}
	
	}

	void Fire()
	{
		lastShotTime = Time.time;
		Debug.Log ("fired");

	if (fireNoise != null) {
		AudioSource.PlayClipAtPoint(fireNoise, shotSpawns[nextShotPoint].transform.position, 1.0f);
	}

	GameObject newShot = Object.Instantiate(
		shotPrefab,
		shotSpawns[nextShotPoint].transform.position,
		transform.rotation
	);

	nextShotPoint = (nextShotPoint + 1) % shotSpawns.Length;
}

}
