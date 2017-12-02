using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Transform player;
	public float launchAngle = 2f;
	public float launchSpeed = 10f;

	private Rigidbody2D rb2d;
	private bool isLaunched = false;
	private Vector3 ballToPlayerVector;

	void Awake() {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		ballToPlayerVector = this.transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLaunched) {
			this.transform.position = player.position + ballToPlayerVector;
			if (Input.GetMouseButtonDown (0)) {
				isLaunched = true;
				rb2d.velocity = new Vector2 (launchAngle, launchSpeed);
			}
		}
	}

	public void ResetBall() {
		rb2d.velocity = Vector2.zero;
		isLaunched = false;
	}
}
