using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public bool gameIsOver;
	public Transform brickHolder;


	[SerializeField] float scoreIncrementValue;

	[Header("UI hooks")]
	[SerializeField] GameObject GameOverPanel;
	[SerializeField] GameObject GameWonPanel;
	[SerializeField] Text livesLabel;
	[SerializeField] Text scoreLabel;
	[SerializeField] Text gOScoreLabel;
	[SerializeField] Text gWScoreLabel;

	private float score;
	private int lives;
	private int amountOfBlocks;


	void Reset() {
		GameWonPanel = GameObject.Find ("GameWonPanel");
		GameOverPanel = GameObject.Find ("GameOverPanel");
		livesLabel = GameObject.Find ("LivesLabel").GetComponent<Text> ();
		scoreLabel = GameObject.Find ("ScoreLabel").GetComponent<Text> ();
		gOScoreLabel = GameObject.Find ("GOScoreDisplayLabel").GetComponent<Text> ();
		gWScoreLabel = GameObject.Find ("GWScoreDisplayLabel").GetComponent<Text> ();
	}

	void Awake() {
		if (Instance == null) {
			Instance = this;
		} else if (Instance != this) {
			Destroy (gameObject);
		}
		amountOfBlocks = brickHolder.childCount;
	}

	void Start() {
		lives = 3;
		livesLabel.text = lives.ToString ();
		StartCoroutine ("scoreIncrementDecrease");
	}

	public void IncrementScoreAndCheckForGW() {
		score += scoreIncrementValue;
		scoreLabel.text = score.ToString ("F0");
		amountOfBlocks--;
		if (amountOfBlocks == 0) {
			GameWon ();
		}
	}

	IEnumerator scoreIncrementDecrease() {
		for (;;) {
			yield return new WaitForSeconds (5f);
			if (!gameIsOver) {
				if (scoreIncrementValue >= 500f) {
					scoreIncrementValue *= 0.98f;
				}
			}
		}
	}

	public bool BallDropped() {
		//returns true if game is not over
		lives--;
		livesLabel.text = lives.ToString ();
		if (lives > 0) {
			return true;
		} else {
			GameOver ();
			return false;
		}
	}

	public void GameOver() {
		Time.timeScale = 0;
		gOScoreLabel.text = score.ToString ("F0");
		GameOverPanel.SetActive (true);
	}

	public void GameWon() {
		Time.timeScale = 0;
		gWScoreLabel.text = score.ToString ("F0");
		GameWonPanel.SetActive (true);

	}

	public void RestartLevel() {
		Time.timeScale = 1;
		SceneManager.LoadScene ("Level_1");
	}
		


}
