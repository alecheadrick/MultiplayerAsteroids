using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleVR;

public class PlayerController : MonoBehaviour
{
	public float startingSpeed = 25;
	public float pitchSpeed = 15;
	public float yawSpeed = 20;
	public float rollSpeed = 10;
	public float throttleAdjust = .1f;
	public float throttleDeadZone = .25f;

	public AudioClip fireNoise;
	public GameObject shotPrefab;
	public GameObject firstPersonCam;
	public GameObject thirdPersonCam;
	public Transform[] shotSpawns;
	public float shotDelay = .5f;

	private float throttle;
	private float lastShotTime;
	public int nextShotPoint = 0;

	void Start()
	{
		if (GameManager.firstPerson)
		{
			thirdPersonCam.SetActive(false);
			firstPersonCam.SetActive(true);
		}
		else {
			thirdPersonCam.SetActive(true);
			firstPersonCam.SetActive(false);
		}

		throttle = startingSpeed;
		lastShotTime = Time.time - shotDelay;
	}

	void Update()
	{
		//float pitch = Input.GetAxis ("Vertical");
		//float yaw = Input.GetAxis ("Horizontal");

		float pitch = 0;
		float yaw = 0;
		
		float x = GvrControllerInput.Orientation.eulerAngles.x;
		float y = GvrControllerInput.Orientation.eulerAngles.y;


		if (x < 90)
		{
			pitch = x / 90;
		}
		else if (x > 270)
		{
			pitch = -(360 - x) / 90;
		}
		else
		{
			pitch = 0;
		}

		if (y < 90)
		{
			yaw = yaw / 90;
		}
		else if (y > 270)
		{
			yaw = (360 - y) / 90;
		}
		else if (y > 90){

			yaw = yaw * 90;
		}
		Debug.Log("yaw is " + yaw);

		this.transform.Rotate(
			1 * pitch * pitchSpeed * Time.deltaTime,
			-1 * yaw * yawSpeed * Time.deltaTime,
			0
			
		);
		//Debug.Log("Pitch: " + pitch + ", Yaw: " + yaw);

		//		Quaternion targetRotation = Quaternion.Euler (
		//			-GvrControllerInput.Orientation.eulerAngles.x,
		//			GvrControllerInput.Orientation.eulerAngles.y,
		//			-GvrControllerInput.Orientation.eulerAngles.z
		//		);
		//
		//		transform.rotation = Quaternion.RotateTowards (
		//			transform.rotation,
		//			targetRotation,
		//			turnSpeed
		//		);

		//		if (Input.GetKey(KeyCode.Alpha1)) {
		//			throttle--;
		//		} else if (Input.GetKey(KeyCode.Alpha2)) {
		//			throttle++;
		//		}

		//		float thumbPositionY = .5f - GvrControllerInput.TouchPos.y;
		//
		//		if (thumbPositionY > throttleDeadZone) {
		//			throttle += throttleAdjust;
		//		} else if (thumbPositionY < -1 * throttleDeadZone) {
		//			throttle -= throttleAdjust;
		//		}

		//		if (GvrControllerInput.IsTouching) {
	//	throttle = 60 * (GvrControllerInput.TouchPosCentered.x);
		//			Debug.Log (GvrControllerInput.TouchPosCentered.y + "/" + throttle);
		//		}

	//	this.transform.Translate(1 * throttle * Time.deltaTime, 0, 0);

		//		if (Input.GetAxis ("Fire2") == 1 && Time.time > lastShotTime + shotDelay) {
		if (GvrControllerInput.ClickButton && Time.time > lastShotTime + shotDelay)
		{
			Fire();
		}
	}

	void Fire()
	{
		lastShotTime = Time.time;

		if (fireNoise != null)
		{
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