using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
	
	bool autoplayOn;
	Transform ball;
	[SerializeField]	float minX;
	[SerializeField]	float maxX;

	void Awake() {
		ball = GameObject.FindGameObjectWithTag ("Ball").transform;
		if (GlobalManager.Instance.selectedControls == GlobalManager.Controls.auto) {
			autoplayOn = true;
		}
	}
		
	void Update () {
		if (!autoplayOn) {
			Move ();
		} else {
			AutoPlay ();
		}
	}
		
	void Move() {
		Vector2 playerPos = new Vector2 (0f, this.transform.position.y);
		float mousePos = Input.mousePosition.x / Screen.width * 16;
		playerPos.x = Mathf.Clamp (mousePos, minX, maxX);
		this.transform.position = playerPos;
	}

	void AutoPlay() {
		Vector2 playerPos = new Vector2 (0f, this.transform.position.y);
		Vector2 ballPos = ball.position;
		playerPos.x = Mathf.Clamp (ballPos.x, minX, maxX);
		this.transform.position = playerPos;
	}
}
