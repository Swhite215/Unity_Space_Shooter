using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	private int score;

	public GUIText restartText;
	public GUIText gameOverText;

	public GameObject boss;

	private bool gameOver;
	private bool restart;
	private bool bossTime;

	void Start() {
		gameOver = false;
		restart = false;
		bossTime = false;

		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		updateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update() 
	{
		if (restart) 
		{
			if (Input.GetKeyDown (KeyCode.R)) 
			{
					SceneManager.LoadScene("Main");
			}
		}	
	}

	IEnumerator SpawnWaves () 
	{
		yield return new WaitForSeconds (startWait);
		while(true) 
		{
			for (var i = 0; i < hazardCount; i++) 
			{
				Vector3 SpawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion SpawnRotation = Quaternion.identity;
				Instantiate (hazard, SpawnPosition, SpawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) 
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}

			if (bossTime) 
			{
				boss.SetActive (true);
				break;
			}
		}

	}

	public void addScore(int newScoreValue) {
		score += newScoreValue;
		updateScore ();
	}

	void updateScore() {
		scoreText.text = "Score: " + score;
		if (score > 10) 
		{
			bossTime = true;
		}
	}

	public void GameOver() 
	{
		if (bossTime == true && !boss.activeSelf) {
			gameOverText.text = "You win! Press 'R' for Restart";
			restart = true;
		} else {
			gameOverText.text = "Game Over";
			gameOver = true;
		}
			
	}

}

