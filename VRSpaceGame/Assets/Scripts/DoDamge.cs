using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamge : MonoBehaviour {
	#region Variables
	public float damage;
	public float destroyTime;
	Transform target;
	public float speed = 5f;
	#endregion

	#region Methods
	private void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player") {
			PlayerHealth.instance.TakeDamage(damage);
		}
		Destroy(gameObject);
	}
	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
		Destroy(gameObject, destroyTime);
	}

	#endregion
}
