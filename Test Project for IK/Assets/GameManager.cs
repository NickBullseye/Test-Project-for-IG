using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public bool gameIsOver;

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
	}

	void Start() {
		lives = 3;
		livesLabel.text = lives.ToString ();
	}

	public void IncrementScore() {
		score += scoreIncrementValue;
		scoreLabel.text = score.ToString ("G");
	}

	public bool BallDropped() {
		//returns true if game is not over
		lives--;
		livesLabel.text = lives.ToString ();
		if (lives > 0) {
			return true;
		} else {
			return false;
		}
	}

	public void GameOver() {
		Time.timeScale = 0;
		gOScoreLabel.text = score.ToString ("D");
		GameOverPanel.SetActive (true);
	}

	public void GameWon() {
		Time.timeScale = 0;
		gWScoreLabel.text = score.ToString ("D");
		GameWonPanel.SetActive (true);

	}

	public void RestartLevel() {
		Time.timeScale = 1;
		SceneManager.LoadScene ("Level_1");
	}
		


}
