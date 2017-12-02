using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float launchAngle = 2f;
	public float launchSpeed = 10f;

	private Transform player;
	private Rigidbody2D rb2d;
	private bool isLaunched = false;
	private Vector3 ballToPlayerVector;

	void Awake() {
		rb2d = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		this.transform.position = new Vector2 (player.transform.position.x, transform.position.y);
	}

	void Start () {
		//stores basic distance from ball to player
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
		//resets ball when lost
		rb2d.velocity = Vector2.zero;
		isLaunched = false;
	}
}
