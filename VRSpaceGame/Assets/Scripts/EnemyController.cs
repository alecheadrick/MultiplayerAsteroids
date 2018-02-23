using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	#region Variables
	public GameObject dropPoint;
	Transform target;
	bool atDropPoint = false;
	public float speed;
	public float range;
	public GameObject shotPoint;
	public GameObject shot;
	public float turnSpeed = 5f;
	bool withinRange = false;
	public float AttackInterval = 3;
	private float elapsedTime = 0;
	#endregion

	#region Methods
	void Awake () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
	{
		float distance = Vector3.Distance(transform.position, target.transform.position);
		if (distance <= range)
		{
			withinRange = true;
			if (Time.time > elapsedTime)
			{
				Shoot();
				elapsedTime = Time.time + AttackInterval;
 }
		}
		if (!atDropPoint)
		{
			MoveToDropPoint();
		}
		else if(!withinRange)
		{
			MoveToPlayer();
		}
	}

	void MoveToDropPoint()
	{
		transform.position = Vector3.MoveTowards(transform.position, dropPoint.transform.position, speed);
		if (transform.position == dropPoint.transform.position) {
			atDropPoint = true;
		}
	}

	void MoveToPlayer() {
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
		Vector3 targetDir = target.position - transform.position;
		float step = turnSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);
	}
	void Shoot() {
		//Debug.Log("Shooting");
		Instantiate(shot, shotPoint.transform.position, Quaternion.identity);
	}
	
	#endregion
}