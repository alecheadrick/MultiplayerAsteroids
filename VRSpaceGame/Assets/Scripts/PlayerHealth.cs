using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	#region Singelton
	public static PlayerHealth instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<PlayerHealth>();
			}
			return _instance;
		}
	}
	static PlayerHealth _instance;

	void Awake()
	{
		_instance = this;
	}
	#endregion

	#region Variables
	public float health;
	public float enemyDamage;
	public Text healthText;
	#endregion

	#region Methods
	public void Start()
	{
		healthText.text = "" + health;
	}

	public void TakeDamage(float damage) {
		health -= damage;
		if (health >= -1) {
			healthText.text = "" + health;
		}
		Debug.Log("Player Takes " + damage + " damage");
	}
	public void Update() {
		if (Input.GetKeyDown(KeyCode.T)) {
			TakeDamage(10);
		}
		if (health <= 0) {
			Die();
		}
	}

	public void Die() {
		Debug.Log("Player Died");
	}
	#endregion
}
