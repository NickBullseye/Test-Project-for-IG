using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

	public bool gameIsOver;

	[SerializeField]	float minX;
	[SerializeField]	float maxX;

	bool autoplayOn;
	Transform ball;


	void Awake() {
		ball = GameObject.FindGameObjectWithTag ("Ball").transform;
		if (GlobalManager.Instance.selectedControls == GlobalManager.Controls.auto) {
			autoplayOn = true;
		}
	}
		
	void Update () {
		if (!gameIsOver) {
			if (!autoplayOn) {
				Move ();
			} else {
				AutoPlay ();
			}
		}
	}
		
	void Move() {
		//move player with the mouse
		Vector2 playerPos = new Vector2 (0f, this.transform.position.y);
		float mousePos = Input.mousePosition.x / Screen.width * 16;
		playerPos.x = Mathf.Clamp (mousePos, minX, maxX);
		this.transform.position = playerPos;
	}

	void AutoPlay() {
		//auto ball follow
		Vector2 playerPos = new Vector2 (0f, this.transform.position.y);
		Vector2 ballPos = ball.position;
		playerPos.x = Mathf.Clamp (ballPos.x, minX, maxX);
		this.transform.position = playerPos;
	}

	public void BonusPickedUp(string bonusType) {
		switch (bonusType) {
		case "ball":
			GameManager.Instance.AddBallPickedUp (this.transform);
			break;
		case "speedUp":
			GameManager.Instance.SpeedUpPickedUp ();
			break;
		default:
			break;
		}
	}
}
