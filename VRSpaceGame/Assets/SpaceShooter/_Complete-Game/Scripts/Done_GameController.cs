using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
	public Transform[] path;
	public float speed = 5.0f;
	public float reachDist = 0f;
	public int currentPoint = 0;
	public Quaternion spawnRotation;
	public GameObject[] hazards;
	public GameObject boss;
	public GameObject player;
    public Vector3 spawnValues;
    public int hazardCount;
	public int bossCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
	public bool done;
	private BossMove bossMove;
	public int ScoreNeededToSpawnBoss;


	private double x;
	private double z;
	private double y;
	private float a;
	private float b;
	private float c;
	private double q;
	private double w;
	private double e;
	private float r;
	private float t;
	private float u;



    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
	public Text youWonText;

	private bool youWon;
	private bool gameOver;
    private bool restart;
    public int score;

    void Start()
    {
		GameObject bossObject = GameObject.FindGameObjectWithTag ("Boss");
		if (bossObject != null)
		{
			bossMove = bossObject.GetComponent <BossMove>();
		}
		if (bossMove == null)
		{
			Debug.Log ("Cannot find 'BossMove' script");
		}

		youWon = false;
		gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
		youWonText.text = "";
        score = 0;
        UpdateScore();
		bossCount = 0;
        StartCoroutine(SpawnWaves());
		done = false;
		x = 0;
		y = 0;
		z = 27.44;
		a = (float)x;
		b = (float)y;
		c = (float)z;
		q = 180.007;
		w = 0.7299957;
		e = 0.5279846;
		r = (float)q;
		t = (float)w;
		u = (float)e;
    }

    void Update()
    {
		if (GameObject.Find ("boss ship") == null) {
			youWon = true;
		}
		if (youWon) {
			youWonText.text = "YOU WON!\nPress 'R' to restart!";
			restart = true;
		}
		bossMove.doneValue(done);

		if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
			for (int i = 0; i < hazardCount; i++)
			{
				if (score >= ScoreNeededToSpawnBoss) {
					done = true;
				}

				yield return done;

				if (done == true) {
					break;
				}
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);


					

            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
  
	}
	public void AddBoss(int newBossCount){
		bossCount += newBossCount;
	}


    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }



    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
	}



    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
	public void YouWon(){
		youWonText.text = "YOU WON! Press 'R' to restart!";
		youWon = true;
	}
}