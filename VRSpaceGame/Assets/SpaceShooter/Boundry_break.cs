using UnityEngine;
using System.Collections;

public class Boundry_break : MonoBehaviour
{
	public GameObject playerShot;
	public GameObject BossShot;

	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.name == "Done_Bolt(Clone)") {
			Destroy(other.gameObject);
		}
		if (other.gameObject.name == "Done_Bolt-Enemy 1(Clone)") {
			Destroy(other.gameObject);
	}
	}
}