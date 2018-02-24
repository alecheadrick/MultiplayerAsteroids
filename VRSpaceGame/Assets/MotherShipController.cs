using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotherShipController : MonoBehaviour {
	#region Variables
	public GameObject enemyToSpawn;
	public GameObject spawnPoint;
	public float spawnWait = 6;
	public float numberOfEnemies = 0;
	public float newNumberOfEnemies;
	public float maxNumberOfEnemies = 10;
	public float wave;
	private float newWave;
	public Text WaveCounter;
	#endregion

	#region Methods
	private void Start()
	{
		wave = 1;
		newWave = wave;
		StartCoroutine(SpawnEnemies());
	}
	private void Update()
	{
		NewWave();
		
	}
	void NewWave() {
		if (wave != newWave) {
			maxNumberOfEnemies = wave * numberOfEnemies;
			//maxNumberOfEnemies = newNumberOfEnemies;
		
			WaveCounter.text = "Wave " + newWave;
		}
	}


	IEnumerator SpawnEnemies() {
		while (true)
		{
			if (newNumberOfEnemies < maxNumberOfEnemies)
			{
				Debug.Log("Starting Spawn");
				Instantiate(enemyToSpawn, spawnPoint.transform.position, Quaternion.identity);
				newNumberOfEnemies++;
				yield return new WaitForSeconds(6f);
			}
			else
			{
				wave++;
				yield return null;
			}
		}
	}
	#endregion
}
